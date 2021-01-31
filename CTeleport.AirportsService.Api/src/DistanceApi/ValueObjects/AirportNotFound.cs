using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CTeleport.AirportsService.Api.ValueObjects;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    /// <summary>
    /// AirportNotFound
    /// </summary>
    public sealed class AirportNotFound : ITypedValueObject, IEquatable<AirportNotFound>
    {
        /// <inheritdoc/>
        [JsonPropertyName("type")]
        [Required]
        public string Type { get => nameof(AirportNotFound); }

        /// <summary>
        /// Airport IATA code
        /// </summary>
        [JsonPropertyName("iata_code")]
        [Required]
        public string IataCode = default!;

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