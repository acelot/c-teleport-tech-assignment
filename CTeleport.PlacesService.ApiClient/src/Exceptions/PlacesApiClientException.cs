using System;

namespace CTeleport.PlacesService.ApiClient.Exceptions
{
    public class PlacesApiClientException : Exception
    {
        public PlacesApiClientException(string message) : base(message) { }

        public PlacesApiClientException(string message, Exception innerException) : base(message, innerException) { }
    }
}