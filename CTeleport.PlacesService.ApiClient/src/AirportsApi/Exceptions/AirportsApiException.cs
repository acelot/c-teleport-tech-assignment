using System;
using CTeleport.PlacesService.ApiClient.Exceptions;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.Exceptions
{
    public class AirportsApiException : PlacesServiceApiClientException
    {
        public AirportsApiException(string message) : base(message) { }

        public AirportsApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}