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
    public class DistanceApiService
    {
        private readonly IAirportsApi _airportsApi;

        private readonly TimeSpan _getAirportLocationTimeout = TimeSpan.FromSeconds(5);

        public DistanceApiService(IAirportsApi airportsApi)
        {
            this._airportsApi = airportsApi;
        }

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
            catch (PlacesApiClientException e)
            {
                throw new DistanceApiServiceException("Cannot get airport", e);
            }
        }

        public double CalculateDistance(Location origin, Location destination, DistanceUnit unit)
        {
            return Geolocation.GeoCalculator.GetDistance(
                origin.Latitude, origin.Longitude,
                destination.Latitude, destination.Longitude,
                0,
                unit switch {
                    DistanceUnit.Meters => Geolocation.DistanceUnit.Meters,
                    DistanceUnit.Kilometers => Geolocation.DistanceUnit.Kilometers,
                    DistanceUnit.Miles => Geolocation.DistanceUnit.Miles,
                    DistanceUnit.NauticalMiles => Geolocation.DistanceUnit.NauticalMiles,
                }
            );
        }
    }
}