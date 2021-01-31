using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    /// <summary>
    /// Location
    /// </summary>
    public sealed class Location
    {
        /// <inheritdoc/>
        [JsonPropertyName("type")]
        [Required]
        public string Type { get => nameof(Location); }

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