using CTeleport.AirportsService.Api.DistanceApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.AirportsService.Api.DistanceApi.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDistanceApi(this IServiceCollection services)
        {
            services.AddScoped<DistanceApiService>();
            
            return services;
        }
    }
}