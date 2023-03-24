using Recaudo.DTOs;
using Recaudo.UseCasesPorts.ConteoVehiculoPorts;

namespace Recaudo.Presenters.ConteoVehiculo
{
    public class GetConteoVehiculoPresenter : IGetConteoVehiculosOutputPort, IPresenter<IEnumerable<ConteoVehiculoDTO>>
    {
        public IEnumerable<ConteoVehiculoDTO> Content { get; private set; }
        public Task Handle(IEnumerable<ConteoVehiculoDTO> conteoVehiculos)
        {
            Content= conteoVehiculos;
            return Task.CompletedTask;
        }
    }
}
