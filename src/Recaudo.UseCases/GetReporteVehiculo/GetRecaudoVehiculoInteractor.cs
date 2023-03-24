using AutoMapper;
using Recaudo.DTOs;
using Recaudo.Entities.Interfaces;
using Recaudo.UseCasesPorts.ConteoVehiculoPorts;
using Recaudo.UseCasesPorts.RecaudoVehiculoPorts;

namespace Recaudo.UseCases.GetReporteVehiculo
{
    public class GetRecaudoVehiculoInteractor : IGetRecaudoVehiculosInputPort
    {
        private readonly IMapper _mapper;
        private readonly IGetRecaudoVehiculosOutputPort _outputPort;
        private readonly IRecaudoVehiculosRepository _repository;
        public GetRecaudoVehiculoInteractor(IMapper mapper, IGetRecaudoVehiculosOutputPort outputPort, IRecaudoVehiculosRepository repository)
        {
            _mapper = mapper;
            _outputPort = outputPort;
            _repository = repository;
        }

        public async Task Handle()
        {
            var recaudoVehiculosDto = _mapper.Map<IEnumerable<RecaudoVehiculoDTO>>(await _repository.GetRecaudoVehiculos());
            await _outputPort.Handle(recaudoVehiculosDto);
        }
    }
}
