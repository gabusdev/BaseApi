using BaseApi.Services;
using BaseApi.Services.Impl;
using DataEF.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApi.Api.AppServices.DI
{
    public static class DIExtensions
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddScoped<IAuthManagerService, AuthManagerService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        }
    }
}
