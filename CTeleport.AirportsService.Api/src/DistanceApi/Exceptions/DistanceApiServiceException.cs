using System;

namespace CTeleport.AirportsService.Api.DistanceApi.Exceptions
{
    /// <summary>
    /// Distance API service common exception
    /// </summary>
    public class DistanceApiServiceException : Exception
    {
        /// <summary>
        /// Constructor with message
        /// </summary>
        public DistanceApiServiceException(string message) : base(message) { }

        /// <summary>
        /// Constructor with message and inner exception
        /// </summary>
        public DistanceApiServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}