using AutoMapper;
using Recaudo.DTOs;
using Recaudo.Entities.Interfaces;
using Recaudo.UseCasesPorts.ReporteRecaudoPosts;

namespace Recaudo.UseCases.ReporteVehiculo
{
    public class ReporteVehiculoInteractor : IGetReporteRecaudoInputPort
    {
        private readonly IMapper _mapper;
        private readonly IGetReporteRecaudoOutputPort _outputPort;
        private readonly IReporteRepository _repository;
        public ReporteVehiculoInteractor(IMapper mapper, IGetReporteRecaudoOutputPort outputPort, IReporteRepository repository)
        {
            _mapper = mapper;
            _outputPort = outputPort;
            _repository = repository;
        }

        public async Task Handle(DateTime fachaInicio, DateTime fechaFin)
        {
            var listDatosReporte = await _repository.GetReporte(fachaInicio, fechaFin);
            var reporteEnBruto = (from conteo in listDatosReporte.Item1
                          join recaudo in listDatosReporte.Item2 on conteo.Estacion equals recaudo.Estacion
                          select new ReporteRecaudoDTO()
                          {
                              Estacion = conteo.Estacion,
                              Cantidad = conteo.Cantidad,
                              Fecha = conteo.Fecha,
                              Valor = recaudo.ValorTabulado
                          }).ToList();

            var reporte = reporteEnBruto.GroupBy(x =>new  { x.Estacion, x.Fecha })
                .Select(x => new ReporteRecaudoDTO()
                {
                    Estacion = x.Key.Estacion,
                    Cantidad = x.Sum(it=>it.Cantidad),
                    Fecha = x.Key.Fecha,
                    Valor = x.Sum(it=>it.Valor)
                }).ToList();


            await _outputPort.Handle(_mapper.Map<IEnumerable<ReporteRecaudoDTO>>(reporte));
        }
    }
}
