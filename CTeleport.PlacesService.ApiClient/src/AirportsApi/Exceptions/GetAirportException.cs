using System;
using CTeleport.PlacesService.ApiClient.Exceptions;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.Exceptions
{
    public class GetAirportException : PlacesApiClientException
    {
        public GetAirportException(string message) : base(message) { }

        public GetAirportException(string message, Exception innerException) : base(message, innerException) { }
    }
}