using Recaudo.DTOs;

namespace Recaudo.UseCasesPorts.ConteoVehiculoPorts
{
    public interface IAddConteoVehiculosInputPort
    {
        Task Handle(AddConteoVehiculoDTO conteoVehiculo);
    }
}
