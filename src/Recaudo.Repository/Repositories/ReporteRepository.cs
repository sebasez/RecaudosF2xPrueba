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
            DateTime fechaFinReporte = new DateTime(fechaFin.Year, fechaFin.Month, fechaFin.Day, 23, 59, 59);
            var listaConteo = await _context.ConteoVehiculos.Where(it => it.Fecha >= fechaInicio && it.Fecha <= fechaFinReporte).ToListAsync();
            var listaRecaudo = await _context.RecaudoVehiculos.Where(it => it.Fecha >= fechaInicio && it.Fecha <= fechaFinReporte).ToListAsync();
            foreach (var item in listaConteo)
            {
                item.Fecha = new DateTime(item.Fecha.Year,item.Fecha.Month,item.Fecha.Day);
            }
            foreach (var item in listaRecaudo)
            {
                item.Fecha = new DateTime(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day);
            }
            return (listaConteo, listaRecaudo);
        }
    }
}
