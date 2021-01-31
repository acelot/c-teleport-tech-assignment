using System.Threading;
using System.Threading.Tasks;
using CTeleport.AirportsService.Api.DistanceApi.Exceptions;
using CTeleport.AirportsService.Api.DistanceApi.ValueObjects;
using CTeleport.AirportsService.Api.ValueObjects;
using CTeleport.PlacesService.ApiClient.AirportsApi;
using CTeleport.PlacesService.ApiClient.Exceptions;
using OneOf;

namespace CTeleport.AirportsService.Api.DistanceApi.Services
{
    /// <summary>
    /// Distance API Service
    /// </summary>
    public class DistanceApiService
    {
        private readonly IAirportsApi _airportsApi;

        /// <summary>
        /// Distance API Service contstructor
        /// </summary>
        public DistanceApiService(IAirportsApi airportsApi)
        {
            this._airportsApi = airportsApi;
        }

        /// <summary>
        /// Fetches an airport by IATA code
        /// </summary>
        public async Task<OneOf<Airport, AirportNotFound>> GetAirport(string iataCode, CancellationToken ct)
        {
            try
            {
                var result = await this._airportsApi.GetAirport(iataCode, ct);

                return result.Match<OneOf<Airport, AirportNotFound>>(
                    airport => new Airport
                    {
                        Name = airport.Name,
                        IataCode = airport.IataCode,
                        Location = new Location
                        {
                            Latitude = airport.Location.Latitude,
                            Longitude = airport.Location.Longitude,
                        }
                    },
                    airportNotFound => new AirportNotFound
                    {
                        IataCode = iataCode
                    }
                );
            }
            catch (PlacesServiceApiClientException e)
            {
                throw new DistanceApiServiceException("Cannot get airport", e);
            }
        }
    }
}