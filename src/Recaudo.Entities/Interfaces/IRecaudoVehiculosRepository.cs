using Recaudo.Entities.POCOs;

namespace Recaudo.Entities.Interfaces
{
    public interface IRecaudoVehiculosRepository
    {
        Task AddRecaudoVehiculo(RecaudoVehiculo recaudoVehiculo);
        Task AddRecaudoVehiculos(IEnumerable<RecaudoVehiculo> recaudoVehiculo);
        Task<IEnumerable<RecaudoVehiculo>> GetRecaudoVehiculos();
        Task<DateTime?> GetFechaMaximaGuardada();
    }
}
