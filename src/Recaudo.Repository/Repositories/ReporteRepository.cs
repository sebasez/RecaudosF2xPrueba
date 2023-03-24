using Microsoft.EntityFrameworkCore;
using Recaudo.Entities.Interfaces;
using Recaudo.Entities.POCOs;
using Recaudo.Repository.DataContext;

namespace Recaudo.Repository.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly RecaudoContext _context;
        public ReporteRepository(RecaudoContext context) =>
            _context = context;

        public async Task<(List<ConteoVehiculo>, List<RecaudoVehiculo>)> GetReporte(DateTime fechaInicio, DateTime fechaFin)
        {
            var listaConteo = await _context.ConteoVehiculos.Where(it => it.Fecha >= fechaInicio && it.Fecha <= fechaFin).ToListAsync();
            var listaRecaudo = await _context.RecaudoVehiculos.Where(it => it.Fecha >= fechaInicio && it.Fecha <= fechaFin).ToListAsync();
            return (listaConteo, listaRecaudo);
        }
    }
}
