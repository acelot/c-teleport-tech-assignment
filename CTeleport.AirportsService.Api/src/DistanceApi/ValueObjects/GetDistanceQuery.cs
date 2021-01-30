using System.ComponentModel.DataAnnotations;
using CTeleport.AirportsService.Api.DistanceApi.Enums;

namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    public class GetDistanceQuery
    {
        [Required(ErrorMessage = "Origin airport IATA code is required")]
        [MinLength(3, ErrorMessage = "IATA code must contain exactly 3 letters")]
        [MaxLength(3, ErrorMessage = "IATA code must contain exactly 3 letters")]
        [RegularExpression(@"^[A-Z]*$", ErrorMessage = "IATA code must contain only capital latin letters")]
        public string Origin { get; set; } = default!;

        [Required(ErrorMessage = "Origin airport IATA code is required")]
        [MinLength(3, ErrorMessage = "IATA code must contain exactly 3 letters")]
        [MaxLength(3, ErrorMessage = "IATA code must contain exactly 3 letters")]
        [RegularExpression(@"^[A-Z]*$", ErrorMessage = "IATA code must contain only capital latin letters")]
        public string Destination { get; set; } = default!;

        public DistanceUnit Unit { get; set; } = DistanceUnit.Miles;
    }
}