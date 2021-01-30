using System;
using System.Net.Http;
using CTeleport.PlacesService.ApiClient.AirportsApi;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.PlacesService.ApiClient.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public const string DevBaseAddress = "https://places-dev.cteleport.com/";

        public static IServiceCollection AddPlacesApiClient(
            this IServiceCollection services,
            string baseAddress = DevBaseAddress
        )
        {
            services.AddHttpClient<PlacesApiClient>(client => ConfigureClient(client, baseAddress));
            services.AddHttpClient<IAirportsApi, PlacesApiClient>(client => ConfigureClient(client, baseAddress));

            return services;
        }

        private static void ConfigureClient(HttpClient client, string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);
        }
    }
}