using System;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects
{
    /// <summary>
    /// AirportNotFound
    /// </summary>
    public sealed class AirportNotFound : IEquatable<AirportNotFound>
    {
        /// <summary>
        /// Airport IATA code
        /// </summary>
        public string IataCode { get; init; } = default!;

        /// <summary>
        /// Equality checker
        /// </summary>
        public bool Equals(AirportNotFound? other)
        {
            return other is not null 
                && IataCode == other.IataCode;
        }
    }
}