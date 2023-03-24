using Microsoft.EntityFrameworkCore;
using Recaudo.Entities.Interfaces;
using Recaudo.Entities.POCOs;
using Recaudo.Repository.DataContext;

namespace Recaudo.Repository.Repositories
{
    public class ConteoVehiculosRepository : IConteoVehiculosRepository
    {
        private readonly RecaudoContext _context;
        public ConteoVehiculosRepository(RecaudoContext context) =>
            _context = context;
        public async Task AddConteoVehiculo(ConteoVehiculo conteoVehiculo)
        {
            conteoVehiculo.Fecha = conteoVehiculo.Fecha.Date + new TimeSpan(conteoVehiculo.Hora, 0, 0);
            await _context.AddAsync(conteoVehiculo);
        }

        public async Task<IEnumerable<ConteoVehiculo>> GetConteoVehiculos()
        {
            return await _context.ConteoVehiculos.ToListAsync();
        }

        public async Task<DateTime?> GetFechaMaximaGuardada()
        {
            return await _context.ConteoVehiculos.MaxAsync(it => it.Fecha);
        }
    }
}
