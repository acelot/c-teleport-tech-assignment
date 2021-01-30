using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using CTeleport.PlacesService.ApiClient.AirportsApi;
using CTeleport.PlacesService.ApiClient.AirportsApi.Exceptions;
using CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects;
using OneOf;

namespace CTeleport.PlacesService.ApiClient
{
    public class PlacesApiClient : IAirportsApi
    {
        public readonly HttpClient _httpClient;

        public PlacesApiClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

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

                throw;
            }
            catch (Exception e)
            {
                throw new GetAirportException("Cannot get airport", e);
            }
        }
    }
}