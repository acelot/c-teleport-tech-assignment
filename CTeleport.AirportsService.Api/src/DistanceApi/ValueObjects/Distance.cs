using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CTeleport.AirportsService.Api.Enums;
using CTeleport.AirportsService.Api.ValueObjects;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    /// <summary>
    /// Distance
    /// </summary>
    public sealed class Distance : ITypedValueObject
    {
        /// <inheritdoc/>
        [JsonPropertyName("type")]
        [Required]
        public string Type { get => nameof(Distance); }

        /// <summary>
        /// Origin airport
        /// </summary>
        [JsonPropertyName("origin")]
        public Airport Origin { get; init; } = default!;

        /// <summary>
        /// Destination airport
        /// </summary>
        [JsonPropertyName("destination")]
        public Airport Destination { get; init; } = default!;

        /// <summary>
        /// Length
        /// </summary>
        [JsonPropertyName("length")]
        public double Length { get; init; }

        /// <summary>
        /// Length unit
        /// </summary>
        [JsonPropertyName("unit")]
        public DistanceUnit Unit { get; init; }
    }
}