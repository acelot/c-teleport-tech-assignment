using System.Text.Json.Serialization;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects
{
    /// <summary>
    /// AirportNotFound
    /// </summary>
    public sealed class Location
    {
        /// <summary>
        /// Latitude
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; init; }

        /// <summary>
        /// Longtitude
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; init; }
    }
}