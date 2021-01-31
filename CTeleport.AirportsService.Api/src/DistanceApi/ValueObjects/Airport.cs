using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    /// <summary>
    /// Airport
    /// </summary>
    public sealed class Airport
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
    }
}