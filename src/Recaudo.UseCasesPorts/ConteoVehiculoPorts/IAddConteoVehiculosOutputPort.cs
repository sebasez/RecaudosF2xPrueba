using Recaudo.DTOs;

namespace Recaudo.UseCasesPorts.ConteoVehiculoPorts
{
    public interface IAddConteoVehiculosOutputPort
    {
        Task Handle(ConteoVehiculoDTO conteoVehiculo);
    }
}
