using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CTeleport.AirportsService.Api.ValueObjects;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    /// <summary>
    /// Airport
    /// </summary>
    public sealed class Airport : ITypedValueObject, IEquatable<Airport>
    {
        /// <inheritdoc/>
        [JsonPropertyName("type")]
        [Required]
        public string Type { get => nameof(Airport); }

        /// <summary>
        /// Airport name
        /// </summary>
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; init; } = default!;

        /// <summary>
        /// Airport IATA code
        /// </summary>
        [JsonPropertyName("iata_code")]
        [Required]
        public string IataCode { get; init; } = default!;

        /// <summary>
        /// Airport geo location
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location { get; init; } = default!;

        /// <summary>
        /// Equality checker
        /// </summary>
        public bool Equals(Airport? other)
        {
            return other is not null
                && Name == other.Name
                && IataCode == other.IataCode
                && Location.Equals(other.Location);
        }
    }
}