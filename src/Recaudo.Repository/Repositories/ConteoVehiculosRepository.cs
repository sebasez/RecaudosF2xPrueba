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

        public async Task AddConteoVehiculos(IEnumerable<ConteoVehiculo> conteoVehiculos)
        {
            foreach (ConteoVehiculo item in conteoVehiculos)
            {
                item.Fecha = item.Fecha.Date + new TimeSpan(item.Hora, 0, 0);
            }
            await _context.AddRangeAsync(conteoVehiculos);
        }

        public async Task<IEnumerable<ConteoVehiculo>> GetConteoVehiculos()
        {
            return await _context.ConteoVehiculos.ToListAsync();
        }

        public async Task<DateTime?> GetFechaMaximaGuardada()
        {
            var entity = _context.ConteoVehiculos.FirstOrDefault();
            if (entity == null)
                return null;
            return await _context.ConteoVehiculos.MaxAsync(it => it.Fecha);
        }
    }
}
