using Recaudo.DTOs;

namespace Recaudo.UseCasesPorts.RecaudoVehiculoPorts
{
    public interface IAddRecaudoVehiculosOutputPort
    {
        Task Handle(RecaudoVehiculoDTO conteoVehiculo);
    }
}
