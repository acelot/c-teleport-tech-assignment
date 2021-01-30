using System.Text.Json.Serialization;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects
{
    public sealed class Location
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}