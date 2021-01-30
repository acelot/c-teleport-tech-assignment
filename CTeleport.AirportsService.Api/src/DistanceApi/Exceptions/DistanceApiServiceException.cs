using System;

namespace CTeleport.AirportsService.Api.DistanceApi.Exceptions
{
    public class DistanceApiServiceException : Exception
    {
        public DistanceApiServiceException(string message) : base(message) { }

        public DistanceApiServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}