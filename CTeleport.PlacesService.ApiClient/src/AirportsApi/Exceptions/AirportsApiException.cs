using System;
using CTeleport.PlacesService.ApiClient.Exceptions;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.Exceptions
{
    /// <summary>
    /// Airports API common exception
    /// </summary>
    public class AirportsApiException : PlacesServiceApiClientException
    {
        /// <summary>
        /// Constructor with message
        /// </summary>
        public AirportsApiException(string message) : base(message) { }

        /// <summary>
        /// Contructor with message and inner exception
        /// </summary>
        public AirportsApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}