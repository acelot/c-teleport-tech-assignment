using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CTeleport.AirportsService.Api.DistanceApi.Enums;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    public sealed class Distance
    {
        [JsonPropertyName("type")]
        [Required]
        public string Type { get => nameof(Distance); }

        [JsonPropertyName("origin")]
        public Airport Origin { get; set; } = default!;

        [JsonPropertyName("destination")]
        public Airport Destination { get; set; } = default!;

        [JsonPropertyName("length")]
        public double Length { get; set; }

        [JsonPropertyName("unit")]
        public DistanceUnit Unit { get; set; }
    }
}