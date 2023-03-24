using AutoMapper;
using Recaudo.DTOs;
using Recaudo.Entities.Interfaces;
using Recaudo.UseCasesPorts.ConteoVehiculoPorts;

namespace Recaudo.UseCases.GetConteoVehiculo
{
    public class GetConteoVehiculoInteractor : IGetConteoVehiculosInputPort
    {
        private readonly IMapper _mapper;
        private readonly IGetConteoVehiculosOutputPort _outputPort;
        private readonly IConteoVehiculosRepository _repository;
        public GetConteoVehiculoInteractor(IMapper mapper, IGetConteoVehiculosOutputPort outputPort, IConteoVehiculosRepository repository)
        {
            _mapper = mapper;
            _outputPort = outputPort;
            _repository = repository;
        }

        public async Task Handle()
        {
            var conteoVehiculosDto = _mapper.Map<IEnumerable<ConteoVehiculoDTO>>(await _repository.GetConteoVehiculos());
            await _outputPort.Handle(conteoVehiculosDto);
        }
    }
}
