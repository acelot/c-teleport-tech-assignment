using System.Text.Json.Serialization;

namespace CTeleport.AirportsService.Api.DistanceApi.Enums
{
    /// <summary>
    /// Distance unit enumeration
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DistanceUnit
    {
        /// <summary>
        /// Meters
        /// </summary>
        Meters,

        /// <summary>
        /// Kilometers
        /// </summary>
        Kilometers,

        /// <summary>
        /// Miles
        /// </summary>
        Miles,

        /// <summary>
        /// Nautial miles
        /// </summary>
        NauticalMiles,
    }
}