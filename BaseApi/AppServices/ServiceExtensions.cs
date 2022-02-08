using BaseApi.Api.AppServices.ApiVersioning;
using BaseApi.Api.AppServices.Authorization;
using BaseApi.Api.AppServices.Caching;
using BaseApi.Api.AppServices.FluentValidation;
using BaseApi.Api.AppServices.Jwt;
using BaseApi.Api.AppServices.MyCors;
using BaseApi.Api.AppServices.MySqlServerContext;
using BaseApi.Api.AppServices.MySwagger;
using BaseApi.Api.AppServices.RateLimit;
using AspNetCoreRateLimit;
using BaseApi.Api.AppServices.Identity;
using DataEF.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BaseApi.Api.Middlewares;
using BaseApi.Services.Utils;
using BaseApi.Services;
using BaseApi.Services.Impl;

namespace Web_Api_Net5.AppServices
{
    public static class ServiceExtensions
    {
        public static void ConfigureServiceExtensions(this IServiceCollection services, IConfiguration conf)
        {
            var conString = conf.GetConnectionString("sqlConnection");
            
            services.ConfigureApiVersioning();
            services.ConfigureAuthorization();
            services.ConfigureCaching();
            services.ConfigureCors();
            services.ConfigureFluentValidation();
            services.ConfigureIdentity();
            services.ConfigureJwt(conf);
            services.ConfigureRateLimit();
            services.ConfigureSqlServerContext(conString);
            services.ConfigureSwagger(conf, true);
            services.AddAuthentication();
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void UseServiceExtensions(this IApplicationBuilder app)
        {
            app.UseMySwagger();
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseCaching();
            app.UseIpRateLimiting();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ErrorWrappingMiddleware));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
