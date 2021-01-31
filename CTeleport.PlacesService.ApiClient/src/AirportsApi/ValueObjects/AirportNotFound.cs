namespace CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects
{
    /// <summary>
    /// AirportNotFound
    /// </summary>
    public sealed class AirportNotFound
    {
        /// <summary>
        /// Airport IATA code
        /// </summary>
        public string IataCode { get; init; } = default!;
    }
}