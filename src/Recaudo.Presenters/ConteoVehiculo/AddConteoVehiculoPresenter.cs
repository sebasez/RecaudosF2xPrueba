using Recaudo.DTOs;
using Recaudo.UseCasesPorts.ConteoVehiculoPorts;

namespace Recaudo.Presenters.ConteoVehiculo
{
    public class AddConteoVehiculoPresenter : IAddConteoVehiculosOutputPort, IPresenter<ConteoVehiculoDTO>
    {
        public ConteoVehiculoDTO Content { get; private set; }
        public Task Handle(ConteoVehiculoDTO conteoVehiculo)
        {
            Content= conteoVehiculo;
            return Task.CompletedTask;
        }
    }
}
