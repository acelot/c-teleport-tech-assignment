using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CTeleport.PlacesService.ApiClient.AirportsApi;
using CTeleport.PlacesService.ApiClient.AirportsApi.Exceptions;
using CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects;
using CTeleport.PlacesService.ApiClient.HttpClientAbstractions;
using OneOf;

namespace CTeleport.PlacesService.ApiClient
{
    /// <summary>
    /// Places Service API Client implementation
    /// </summary>
    public sealed class PlacesServiceApiClient : IAirportsApi
    {
        private readonly IHttpClient _httpClient;

        /// <summary>
        /// Places Service API Client constructor
        /// </summary>
        public PlacesServiceApiClient(IHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        /// <inheritdoc/>
        public async Task<OneOf<Airport, AirportNotFound>> GetAirport(string iataCode, CancellationToken ct)
        {
            try
            {
                var result = await this._httpClient.GetFromJsonAsync<Airport>($"airports/{iataCode}", ct);
                if (result is null)
                {
                    return new AirportNotFound { IataCode = iataCode };
                }

                return result;
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return new AirportNotFound { IataCode = iataCode };
                }

                throw new GetAirportException("Cannot get airport", e);
            }
        }
    }
}