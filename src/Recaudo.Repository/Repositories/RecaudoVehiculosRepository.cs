using Microsoft.EntityFrameworkCore;
using Recaudo.Entities.Interfaces;
using Recaudo.Entities.POCOs;
using Recaudo.Repository.DataContext;

namespace Recaudo.Repository.Repositories
{
    public class RecaudoVehiculosRepository : IRecaudoVehiculosRepository
    {
        private readonly RecaudoContext _context;
        public RecaudoVehiculosRepository(RecaudoContext context) =>
            _context = context;

        public async Task AddRecaudoVehiculo(RecaudoVehiculo recaudoVehiculo)
        {
            recaudoVehiculo.Fecha = recaudoVehiculo.Fecha.Date + new TimeSpan(recaudoVehiculo.Hora, 0, 0);
            await _context.AddAsync(recaudoVehiculo);
        }

        public async Task AddRecaudoVehiculos(IEnumerable<RecaudoVehiculo> recaudoVehiculo)
        {
            foreach (RecaudoVehiculo item in recaudoVehiculo)
            {
                item.Fecha = item.Fecha.Date + new TimeSpan(item.Hora, 0, 0);
            }
            await _context.AddRangeAsync(recaudoVehiculo);
        }

        public async Task<DateTime?> GetFechaMaximaGuardada()
        {
            var entity = _context.RecaudoVehiculos.FirstOrDefault();
            if (entity == null)
                return null;
            return await _context.RecaudoVehiculos.MaxAsync(it => it.Fecha);
        }

        public async Task<IEnumerable<RecaudoVehiculo>> GetRecaudoVehiculos()
        {
            return await _context.RecaudoVehiculos.Take(10).ToListAsync();
        }
    }
}
