using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recaudo.Entities.Interfaces;
using Recaudo.Repository.DataContext;
using Recaudo.Repository.Repositories;

namespace Recaudo.Repository
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RecaudoContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IConteoVehiculosRepository, ConteoVehiculosRepository>();
            services.AddScoped<IRecaudoVehiculosRepository, RecaudoVehiculosRepository>();
            services.AddScoped<IReporteRepository, ReporteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
