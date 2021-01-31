using System.ComponentModel.DataAnnotations;
using CTeleport.AirportsService.Api.Enums;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    /// <summary>
    /// Distance API GET-method query object
    /// </summary>
    public sealed class GetDistanceQuery
    {
        /// <summary>
        /// Origin airport IATA code
        /// </summary>
        [Required(ErrorMessage = "Origin airport IATA code is required")]
        [MinLength(3, ErrorMessage = "IATA code must contain exactly 3 letters")]
        [MaxLength(3, ErrorMessage = "IATA code must contain exactly 3 letters")]
        [RegularExpression(@"^[A-Z]*$", ErrorMessage = "IATA code must contain only capital latin letters")]
        public string Origin { get; init; } = default!;

        /// <summary>
        /// Destination airport IATA code
        /// </summary>
        [Required(ErrorMessage = "Origin airport IATA code is required")]
        [MinLength(3, ErrorMessage = "IATA code must contain exactly 3 letters")]
        [MaxLength(3, ErrorMessage = "IATA code must contain exactly 3 letters")]
        [RegularExpression(@"^[A-Z]*$", ErrorMessage = "IATA code must contain only capital latin letters")]
        public string Destination { get; init; } = default!;

        /// <summary>
        /// Desired distance unit
        /// </summary>
        public DistanceUnit Unit { get; init; } = DistanceUnit.Miles;
    }
}