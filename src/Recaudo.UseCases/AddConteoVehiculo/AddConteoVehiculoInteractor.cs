using AutoMapper;
using Recaudo.DTOs;
using Recaudo.Entities.Exceptions;
using Recaudo.Entities.Interfaces;
using Recaudo.Entities.POCOs;
using Recaudo.UseCasesPorts.ConteoVehiculoPorts;

namespace Recaudo.UseCases.AddConteoVehiculo
{
    public class AddConteoVehiculoInteractor : IAddConteoVehiculosInputPort
    {
        private readonly IMapper _mapper;
        private readonly IAddConteoVehiculosOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConteoVehiculosRepository _repository;
        public AddConteoVehiculoInteractor(IMapper mapper, IAddConteoVehiculosOutputPort outputPort, IUnitOfWork unitOfWork, IConteoVehiculosRepository repository)
        {
            _mapper = mapper;
            _outputPort = outputPort;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Handle(AddConteoVehiculoDTO conteoVehiculo)
        {
            var newConteoVehiculo = _mapper.Map<ConteoVehiculo>(conteoVehiculo);
            await _repository.AddConteoVehiculo(newConteoVehiculo);
            try
            {
                await _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el conteo de vehículos", ex.Message);
            }
            await _outputPort.Handle(_mapper.Map<ConteoVehiculoDTO>(newConteoVehiculo));
        }
    }
}
