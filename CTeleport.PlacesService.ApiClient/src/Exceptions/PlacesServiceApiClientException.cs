using System;

namespace CTeleport.PlacesService.ApiClient.Exceptions
{
    public class PlacesServiceApiClientException : Exception
    {
        public PlacesServiceApiClientException(string message) : base(message) { }

        public PlacesServiceApiClientException(string message, Exception innerException) : base(message, innerException) { }
    }
}