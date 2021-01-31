using System;

namespace CTeleport.PlacesService.ApiClient.Exceptions
{
    /// <summary>
    /// Places Service API Client common exception
    /// </summary>
    public class PlacesServiceApiClientException : Exception
    {
        /// <summary>
        /// Constructor with message
        /// </summary>
        public PlacesServiceApiClientException(string message) : base(message) { }

        /// <summary>
        /// Constructor with message and inner exception
        /// </summary>
        public PlacesServiceApiClientException(string message, Exception innerException) : base(message, innerException) { }
    }
}