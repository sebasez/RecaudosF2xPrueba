using Recaudo.DTOs;
using Recaudo.UseCasesPorts.RecaudoVehiculoPorts;

namespace Recaudo.Presenters.RecaudoVehiculo
{
    public class AddRecaudoVehiculoPresenter : IAddRecaudoVehiculosOutputPort, IPresenter<RecaudoVehiculoDTO>
    {
        public RecaudoVehiculoDTO Content { get; private set; }
        public Task Handle(RecaudoVehiculoDTO conteoVehiculo)
        {
            Content = conteoVehiculo;
            return Task.CompletedTask;
        }
    }
}
