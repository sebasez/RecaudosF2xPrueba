using Recaudo.DTOs;

namespace Recaudo.UseCasesPorts.RecaudoVehiculoPorts
{
    public interface IGetRecaudoVehiculosOutputPort
    {
        Task Handle(IEnumerable<RecaudoVehiculoDTO> recaudoVehiculo);
    }
}
