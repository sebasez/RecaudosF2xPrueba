using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recaudo.ConsultaRecaudo;
using Recaudo.Presenters;
using Recaudo.Repository;
using Recaudo.UseCases;

namespace Recaudo.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRecaudoVehiculosDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices();
            services.AddPresenters();
            services.AddServices();
            return services;
        }
    }
}
