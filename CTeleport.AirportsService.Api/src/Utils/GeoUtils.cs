using CTeleport.AirportsService.Api.Enums;
using CTeleport.AirportsService.Api.ValueObjects;

namespace CTeleport.AirportsService.Api.Utils
{
    /// <summary>
    /// Collection of geo utilities
    /// </summary>
    public sealed class GeoUtils : IGeoUtils
    {
        /// <inheritdoc/>
        /// <exception cref="System.ArgumentException">Thrown when location is invalid</exception>
        public double CalculateDistance(Location origin, Location destination, DistanceUnit unit)
        {
            var (distanceUnit, precision) = unit switch
            {
                DistanceUnit.Kilometers => (Geolocation.DistanceUnit.Kilometers, 3),
                DistanceUnit.Miles => (Geolocation.DistanceUnit.Miles, 3),
                DistanceUnit.NauticalMiles => (Geolocation.DistanceUnit.NauticalMiles, 3),
                _ => (Geolocation.DistanceUnit.Meters, 1),
            };

            return Geolocation.GeoCalculator.GetDistance(
                origin.Latitude, origin.Longitude,
                destination.Latitude, destination.Longitude,
                precision,
                distanceUnit
            );
        }
    }
}