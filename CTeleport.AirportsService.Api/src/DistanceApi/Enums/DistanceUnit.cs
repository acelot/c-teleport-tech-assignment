using System.Text.Json.Serialization;

namespace CTeleport.AirportsService.Api.DistanceApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DistanceUnit
    {
        Meters,
        Kilometers,
        Miles,
        NauticalMiles,
    }
}