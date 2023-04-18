using Microsoft.Extensions.DependencyInjection;
using Recaudo.Entities.InterfacesServices;

namespace Recaudo.ConsultaRecaudo
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IObtenerDatosExternosService, RecaudoObtenerConteoVehiculos>();
            return services;
        }
    }
}
