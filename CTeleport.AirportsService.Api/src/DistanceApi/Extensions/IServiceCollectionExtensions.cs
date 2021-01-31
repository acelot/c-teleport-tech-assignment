using CTeleport.AirportsService.Api.DistanceApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.AirportsService.Api.DistanceApi.Extensions
{
    /// <summary>
    /// Services configuration helpers
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Distance API service
        /// </summary>
        public static IServiceCollection AddDistanceApi(this IServiceCollection services)
        {
            services.AddScoped<DistanceApiService>();
            
            return services;
        }
    }
}