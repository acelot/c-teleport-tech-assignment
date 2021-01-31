using System.Text.Json.Serialization;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects
{
    /// <summary>
    /// Airport
    /// </summary>
    public sealed class Airport
    {
        /// <summary>
        /// Airport name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; } = default!;

        /// <summary>
        /// Airport IATA code
        /// </summary>
        [JsonPropertyName("iata")]
        public string IataCode { get; init; } = default!;

        /// <summary>
        /// Airport location
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location { get; init; } = default!;

        /// <summary>
        /// Airport timezone region
        /// </summary>
        [JsonPropertyName("timezone_region_name")]
        public string TimezoneRegionName { get; init; } = default!;

        /// <summary>
        /// Airport hubs count
        /// </summary>
        [JsonPropertyName("hubs")]
        public uint Hubs { get; init; }

        /// <summary>
        /// Airport rating
        /// </summary>
        [JsonPropertyName("rating")]
        public uint Rating { get; init; }

        /// <summary>
        /// Airport country name
        /// </summary>
        [JsonPropertyName("country")]
        public string CountryName { get; init; } = default!;

        /// <summary>
        /// Airport country IATA code
        /// </summary>
        [JsonPropertyName("country_iata")]
        public string CountryIataCode { get; init; } = default!;

        /// <summary>
        /// Airport city name
        /// </summary>
        [JsonPropertyName("city")]
        public string CityName { get; init; } = default!;

        /// <summary>
        /// Airport city IATA code
        /// </summary>
        [JsonPropertyName("city_iata")]
        public string CityIataCode { get; init; } = default!;
    }
}