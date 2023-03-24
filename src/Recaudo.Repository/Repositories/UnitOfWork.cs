using Recaudo.Entities.Interfaces;
using Recaudo.Repository.DataContext;

namespace Recaudo.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecaudoContext _context;
        public UnitOfWork(RecaudoContext context)=>
            _context = context;

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
