using Microsoft.EntityFrameworkCore;
using Recaudo.Entities.Interfaces;
using Recaudo.Entities.POCOs;
using Recaudo.Repository.DataContext;

namespace Recaudo.Repository.Repositories
{
    public class RecaudoVehiculosRepository : IRecaudoVehiculosRepository
    {
        private readonly RecaudoContext _context;
        public RecaudoVehiculosRepository(RecaudoContext context)=>
            _context = context;
        
        public async Task AddRecaudoVehiculo(RecaudoVehiculo recaudoVehiculo)
        {
            recaudoVehiculo.Fecha = recaudoVehiculo.Fecha.Date + new TimeSpan(recaudoVehiculo.Hora, 0, 0);
            await _context.AddAsync(recaudoVehiculo);
        }

        public async Task<DateTime?> GetFechaMaximaGuardada()
        {
            return await _context.RecaudoVehiculos.MaxAsync(it => it.Fecha);
        }

        public async Task<IEnumerable<RecaudoVehiculo>> GetRecaudoVehiculos()
        {
            return await _context.RecaudoVehiculos.ToListAsync();
        }
    }
}
