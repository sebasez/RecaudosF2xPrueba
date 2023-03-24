using Recaudo.Entities.POCOs;

namespace Recaudo.Entities.Interfaces
{
    public interface IReporteRepository
    {
        Task<(List<ConteoVehiculo>, List<RecaudoVehiculo>)> GetReporte(DateTime fechaInicio, DateTime fechaFin);
    }
}
