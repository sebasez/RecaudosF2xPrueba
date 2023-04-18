using AutoMapper;
using Recaudo.DTOs;
using Recaudo.Entities.Exceptions;
using Recaudo.Entities.Interfaces;
using Recaudo.Entities.InterfacesServices;
using Recaudo.Entities.POCOs;
using Recaudo.UseCases.AddConteoVehiculo;
using Recaudo.UseCasesPorts.ProcesarDatosPorts;
using System.Linq;
using System.Text.Json;

namespace Recaudo.UseCases.ProcesoDatos
{
    public class ProcesarDataInteractor : IProcesoDatosInputPort
    {
        private readonly IProcesoDatosOutputPort _outputPort;
        private readonly IConteoVehiculosRepository _repositoryConteo;
        private readonly IRecaudoVehiculosRepository _repositoryRecaudo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IObtenerDatosExternosService _service;
        private readonly IMapper _mapper;
        public ProcesarDataInteractor(IProcesoDatosOutputPort outputPort,
            IConteoVehiculosRepository repositoryConteo,
            IRecaudoVehiculosRepository repositoryRecaudo,
            IUnitOfWork unitOfWork,
            IObtenerDatosExternosService service,
            IMapper mapper)
        {
            _outputPort = outputPort;
            _repositoryConteo = repositoryConteo;
            _repositoryRecaudo = repositoryRecaudo;
            _unitOfWork = unitOfWork;
            _service = service;
            _mapper = mapper;
        }

        public async Task Handle(DateTime fecha)
        {
            DateTime fechaProcesadaActual;
            try
            {
                var fechaMaximaConteo = await _repositoryConteo.GetFechaMaximaGuardada();
                if (fechaMaximaConteo == null)
                    await AdicionDatosDeConteoDeVehiculos(fecha);
                else
                    await AdicionDatosDeConteoDeVehiculos(fechaMaximaConteo.Value.AddDays(1));
                var fechaMaximaRecaudo = await _repositoryRecaudo.GetFechaMaximaGuardada();
                if (fechaMaximaRecaudo == null)
                    await AdicionDatosDeRecaudoDeVehiculos(fecha);
                else
                    await AdicionDatosDeRecaudoDeVehiculos(fechaMaximaConteo.Value.AddDays(1));
                await _unitOfWork.SaveChanges();
                fechaProcesadaActual = fechaMaximaConteo.Value.AddDays(1);
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al cargar informacion recaudos", ex.Message);
            }
            await _outputPort.Handle(fechaProcesadaActual);
        }

        private async Task AdicionDatosDeConteoDeVehiculos(DateTime? fechaMaxima)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var responseConteo = await _service.ObtenerDatos(new FiltroConsultaGeneralRequest { FechaConsulta = fechaMaxima.Value, ApiServicio = "ConteoVehiculos" });
            var datos = JsonSerializer.Deserialize<IEnumerable<AddConteoVehiculoDTO>>(responseConteo, options);
            foreach (AddConteoVehiculoDTO item in datos)
            {
                item.Fecha = fechaMaxima.Value;
            }
            await _repositoryConteo.AddConteoVehiculos(_mapper.Map<IEnumerable<ConteoVehiculo>>(datos));
        }
        private async Task AdicionDatosDeRecaudoDeVehiculos(DateTime? fechaMaxima)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var responseConteo = await _service.ObtenerDatos(new FiltroConsultaGeneralRequest { FechaConsulta = fechaMaxima.Value.AddDays(1), ApiServicio = "RecaudoVehiculos" });
            var datos = JsonSerializer.Deserialize<IEnumerable<AddRecaudoVehiculoDTO>>(responseConteo, options);
            foreach (AddRecaudoVehiculoDTO item in datos)
            {
                item.Fecha = fechaMaxima.Value;
            }
            await _repositoryRecaudo.AddRecaudoVehiculos(_mapper.Map<IEnumerable<RecaudoVehiculo>>(datos));
        }
    }
}
