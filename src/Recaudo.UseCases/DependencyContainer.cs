using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Recaudo.UseCases.AddConteoVehiculo;
using Recaudo.UseCases.AddReporteVehiculo;
using Recaudo.UseCases.GetConteoVehiculo;
using Recaudo.UseCases.GetReporteVehiculo;
using Recaudo.UseCases.Mappings;
using Recaudo.UseCases.ReporteVehiculo;
using Recaudo.UseCasesPorts.ConteoVehiculoPorts;
using Recaudo.UseCasesPorts.RecaudoVehiculoPorts;
using Recaudo.UseCasesPorts.ReporteRecaudoPosts;

namespace Recaudo.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IAddConteoVehiculosInputPort, AddConteoVehiculoInteractor>();
            services.AddTransient<IGetConteoVehiculosInputPort, GetConteoVehiculoInteractor>();
            services.AddTransient<IAddRecaudoVehiculosInputPort, AddRecaudoVehiculoInteractor>();
            services.AddTransient<IGetRecaudoVehiculosInputPort, GetRecaudoVehiculoInteractor>();
            services.AddTransient<IGetReporteRecaudoInputPort, ReporteVehiculoInteractor>();

            return services;
        }
    }
}
