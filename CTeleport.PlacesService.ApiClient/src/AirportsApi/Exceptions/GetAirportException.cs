using System;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.Exceptions
{
    /// <summary>
    /// GetAirport method exception
    /// </summary>
    public sealed class GetAirportException : AirportsApiException
    {
        /// <summary>
        /// Constructor with message
        /// </summary>
        public GetAirportException(string message) : base(message) { }

        /// <summary>
        /// Constructor with message and inner exception
        /// </summary>
        public GetAirportException(string message, Exception innerException) : base(message, innerException) { }
    }
}