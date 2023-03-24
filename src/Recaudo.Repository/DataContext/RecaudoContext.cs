using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Recaudo.Entities.POCOs;
using Recaudo.Repository.Repositories;

namespace Recaudo.Repository.DataContext
{
    public class RecaudoContext : DbContext
    {
        public RecaudoContext(DbContextOptions<RecaudoContext> options) 
            : base(options)
        {
        }

        public DbSet<ConteoVehiculo> ConteoVehiculos { get; set; }
        public DbSet<RecaudoVehiculo> RecaudoVehiculos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ConteoVehiculo>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<RecaudoVehiculo>()
                .HasKey(t => t.Id);
            
        }
    }
}
