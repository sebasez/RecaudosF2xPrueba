using AutoMapper;
using Recaudo.DTOs;
using Recaudo.Entities.Exceptions;
using Recaudo.Entities.Interfaces;
using Recaudo.Entities.POCOs;
using Recaudo.UseCasesPorts.RecaudoVehiculoPorts;

namespace Recaudo.UseCases.AddReporteVehiculo
{
    public class AddRecaudoVehiculoInteractor : IAddRecaudoVehiculosInputPort
    {
        private readonly IMapper _mapper;
        private readonly IAddRecaudoVehiculosOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecaudoVehiculosRepository _repository;
        public AddRecaudoVehiculoInteractor(IMapper mapper, IAddRecaudoVehiculosOutputPort outputPort, IUnitOfWork unitOfWork, IRecaudoVehiculosRepository repository)
        {
            _mapper = mapper;
            _outputPort = outputPort;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Handle(AddRecaudoVehiculoDTO conteoVehiculo)
        {
            var newRecaudoVehiculo = _mapper.Map<RecaudoVehiculo>(conteoVehiculo);
            await _repository.AddRecaudoVehiculo(newRecaudoVehiculo);
            try
            {
                await _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el conteo de vehículos", ex.Message);
            }
            await _outputPort.Handle(_mapper.Map<RecaudoVehiculoDTO>(newRecaudoVehiculo));
        }
    }
}
