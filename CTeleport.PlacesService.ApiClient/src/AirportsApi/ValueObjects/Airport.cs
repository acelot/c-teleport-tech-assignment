using System.Text.Json.Serialization;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects
{
    public sealed class Airport
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("iata")]
        public string IataCode { get; set; } = default!;

        [JsonPropertyName("location")]
        public Location Location { get; set; } = default!;

        [JsonPropertyName("timezone_region_name")]
        public string TimezoneRegionName { get; set; } = default!;

        [JsonPropertyName("hubs")]
        public uint Hubs { get; set; }

        [JsonPropertyName("rating")]
        public uint Rating { get; set; }

        [JsonPropertyName("country")]
        public string CountryName { get; set; } = default!;

        [JsonPropertyName("country_iata")]
        public string CountryIataCode { get; set; } = default!;

        [JsonPropertyName("city")]
        public string CityName { get; set; } = default!;

        [JsonPropertyName("city_iata")]
        public string CityIataCode { get; set; } = default!;
    }
}