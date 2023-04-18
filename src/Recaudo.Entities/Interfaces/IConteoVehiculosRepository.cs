using Recaudo.Entities.POCOs;

namespace Recaudo.Entities.Interfaces
{
    public interface IConteoVehiculosRepository
    {
        Task AddConteoVehiculo(ConteoVehiculo conteoVehiculo);
        Task AddConteoVehiculos(IEnumerable<ConteoVehiculo> conteoVehiculos);
        Task<IEnumerable<ConteoVehiculo>> GetConteoVehiculos();
        Task<DateTime?> GetFechaMaximaGuardada();
    }
}
