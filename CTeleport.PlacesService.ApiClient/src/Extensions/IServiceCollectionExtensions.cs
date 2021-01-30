using System;
using System.Net.Http;
using CTeleport.PlacesService.ApiClient.AirportsApi;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.PlacesService.ApiClient.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPlacesServiceApiClient(
            this IServiceCollection services,
            Uri baseAddress
        )
        {
            services.AddHttpClient<PlacesServiceApiClient>(client => ConfigureClient(client, baseAddress));
            services.AddHttpClient<IAirportsApi, PlacesServiceApiClient>(client => ConfigureClient(client, baseAddress));

            return services;
        }

        private static void ConfigureClient(HttpClient client, Uri baseAddress)
        {
            client.BaseAddress = baseAddress;
        }
    }
}