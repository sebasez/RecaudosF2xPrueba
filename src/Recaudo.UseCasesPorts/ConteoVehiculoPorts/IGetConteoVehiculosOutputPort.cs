using Recaudo.DTOs;

namespace Recaudo.UseCasesPorts.ConteoVehiculoPorts
{
    public interface IGetConteoVehiculosOutputPort
    {
        Task Handle(IEnumerable<ConteoVehiculoDTO> conteoVehiculos);
    }
}
