using Recaudo.Entities.POCOs;

namespace Recaudo.Entities.Interfaces
{
    public interface IConteoVehiculosRepository
    {
        Task AddConteoVehiculo(ConteoVehiculo conteoVehiculo);
        Task<IEnumerable<ConteoVehiculo>> GetConteoVehiculos();
        Task<DateTime?> GetFechaMaximaGuardada();
    }
}
