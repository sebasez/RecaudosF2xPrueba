using Recaudo.DTOs;

namespace Recaudo.UseCasesPorts.RecaudoVehiculoPorts
{
    public interface IAddRecaudoVehiculosInputPort
    {
        Task Handle(AddRecaudoVehiculoDTO conteoVehiculo);
    }
}
