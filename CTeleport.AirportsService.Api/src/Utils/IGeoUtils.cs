using CTeleport.AirportsService.Api.Enums;
using CTeleport.AirportsService.Api.ValueObjects;

namespace CTeleport.AirportsService.Api.Utils
{
    /// <summary>
    /// Geo utilities common interface
    /// </summary>
    public interface IGeoUtils
    {
        /// <summary>
        /// Calculates the distance between two locations in given unit
        /// </summary>
        double CalculateDistance(Location origin, Location destination, DistanceUnit unit);
    }
}