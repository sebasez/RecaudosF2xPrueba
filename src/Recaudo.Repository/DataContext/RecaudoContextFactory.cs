using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Recaudo.Repository.DataContext
{
    public class RecaudoContextFactory : IDesignTimeDbContextFactory<RecaudoContext>
    {
        public RecaudoContext CreateDbContext(string[] args)
        {
            var OptionUser = new OperationalStoreOptions();
            var OptionsBuilder = new DbContextOptionsBuilder<RecaudoContext>();
            OptionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=RecaudoVehiculos;TrustServerCertificate=True;User Id=prueba;Password=prueba;");
            return new RecaudoContext(OptionsBuilder.Options);
        }
    }
}
