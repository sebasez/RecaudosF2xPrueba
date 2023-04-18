using Microsoft.Extensions.DependencyInjection;
using Recaudo.Presenters.ConsultaRecaudo;
using Recaudo.Presenters.ConteoVehiculo;
using Recaudo.Presenters.RecaudoVehiculo;
using Recaudo.Presenters.ReporteRecaudo;
using Recaudo.UseCasesPorts.ConteoVehiculoPorts;
using Recaudo.UseCasesPorts.ProcesarDatosPorts;
using Recaudo.UseCasesPorts.RecaudoVehiculoPorts;
using Recaudo.UseCasesPorts.ReporteRecaudoPosts;

namespace Recaudo.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<IAddConteoVehiculosOutputPort, AddConteoVehiculoPresenter>();
            services.AddScoped<IGetConteoVehiculosOutputPort, GetConteoVehiculoPresenter>();
            services.AddScoped<IAddRecaudoVehiculosOutputPort, AddRecaudoVehiculoPresenter>();
            services.AddScoped<IGetRecaudoVehiculosOutputPort, GetRecaudoVehiculoPresenter>();
            services.AddScoped<IGetReporteRecaudoOutputPort, GetReporteVehiculoPresenter>();
            services.AddScoped<IProcesoDatosOutputPort, ServiciosVehiculoPresenter>();
            return services;
        }
    }
}
