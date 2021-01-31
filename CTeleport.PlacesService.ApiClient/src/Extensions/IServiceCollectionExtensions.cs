using System;
using CTeleport.PlacesService.ApiClient.AirportsApi;
using CTeleport.PlacesService.ApiClient.HttpClientAbstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.PlacesService.ApiClient.Extensions
{
    /// <summary>
    /// Services configuration helpers
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Places Service API Client
        /// </summary>
        public static IServiceCollection AddPlacesServiceApiClient(
            this IServiceCollection services,
            Uri baseAddress
        )
        {
            services.AddHttpClient<HttpClient>(client => ConfigureClient(client, baseAddress));
            services.AddHttpClient<IHttpClient, HttpClient>(client => ConfigureClient(client, baseAddress));

            services.AddScoped<PlacesServiceApiClient>();
            services.AddScoped<IAirportsApi, PlacesServiceApiClient>();

            return services;
        }

        private static void ConfigureClient(System.Net.Http.HttpClient client, Uri baseAddress)
        {
            client.BaseAddress = baseAddress;
        }
    }
}