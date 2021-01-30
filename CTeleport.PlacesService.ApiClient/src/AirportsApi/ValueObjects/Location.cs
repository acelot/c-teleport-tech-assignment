using System.Text.Json.Serialization;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects
{
    public class Location
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}