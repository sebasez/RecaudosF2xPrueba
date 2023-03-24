using Recaudo.DTOs;
using Recaudo.UseCasesPorts.RecaudoVehiculoPorts;

namespace Recaudo.Presenters.RecaudoVehiculo
{
    public class GetRecaudoVehiculoPresenter : IGetRecaudoVehiculosOutputPort, IPresenter<IEnumerable<RecaudoVehiculoDTO>>
    {
        public IEnumerable<RecaudoVehiculoDTO> Content { get; private set; }

        public Task Handle(IEnumerable<RecaudoVehiculoDTO> recaudoVehiculos)
        {
            Content = recaudoVehiculos;
            return Task.CompletedTask; 
        }
    }
}
