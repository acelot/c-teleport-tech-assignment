using System;
using System.Threading;
using System.Threading.Tasks;
using CTeleport.AirportsService.Api.DistanceApi.Enums;
using CTeleport.AirportsService.Api.DistanceApi.Exceptions;
using CTeleport.AirportsService.Api.DistanceApi.ValueObjects;
using CTeleport.PlacesService.ApiClient.AirportsApi;
using CTeleport.PlacesService.ApiClient.Exceptions;

namespace CTeleport.AirportsService.Api.DistanceApi.Services
{
    /// <summary>
    /// Distance API Service
    /// </summary>
    public class DistanceApiService
    {
        private readonly IAirportsApi _airportsApi;

        private readonly TimeSpan _getAirportLocationTimeout = TimeSpan.FromSeconds(5);

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
        public async Task<Airport?> GetAirport(string iataCode)
        {
            try
            {
                using (var cts = new CancellationTokenSource(this._getAirportLocationTimeout))
                {
                    var result = await this._airportsApi.GetAirport(iataCode, cts.Token);

                    return result.Match(
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
                        airportNotFound => null as Airport
                    );
                }
            }
            catch (PlacesServiceApiClientException e)
            {
                throw new DistanceApiServiceException("Cannot get airport", e);
            }
        }

        /// <summary>
        /// Calculates the distance between two locations in given unit
        /// </summary>
        public double CalculateDistance(Location origin, Location destination, DistanceUnit unit)
        {
            var distanceUnit = unit switch
            {
                DistanceUnit.Kilometers => Geolocation.DistanceUnit.Kilometers,
                DistanceUnit.Miles => Geolocation.DistanceUnit.Miles,
                DistanceUnit.NauticalMiles => Geolocation.DistanceUnit.NauticalMiles,
                _ => Geolocation.DistanceUnit.Meters,
            };

            return Geolocation.GeoCalculator.GetDistance(
                origin.Latitude, origin.Longitude,
                destination.Latitude, destination.Longitude,
                0,
                distanceUnit
            );
        }
    }
}