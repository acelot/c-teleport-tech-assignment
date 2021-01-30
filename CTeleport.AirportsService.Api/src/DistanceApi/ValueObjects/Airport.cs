using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    public class Airport
    {
        [JsonPropertyName("type")]
        [Required]
        public string Type { get => nameof(Airport); }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; } = default!;

        [JsonPropertyName("iata_code")]
        [Required]
        public string IataCode { get; set; } = default!;

        [JsonPropertyName("location")]
        public Location Location { get; set; } = default!;
    }
}