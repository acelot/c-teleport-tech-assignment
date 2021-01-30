using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    public class Location
    {
        [JsonPropertyName("type")]
        [Required]
        public string Type { get => nameof(Location); }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}