using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CTeleport.AirportsService.Api.ValueObjects
{
    /// <summary>
    /// Location
    /// </summary>
    public sealed class Location : IEquatable<Location>
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

        /// <summary>
        /// Equality checker
        /// </summary>
        public bool Equals(Location? other)
        {
            return other is not null
                && Latitude == other.Latitude
                && Longitude == other.Longitude;
        }
    }
}