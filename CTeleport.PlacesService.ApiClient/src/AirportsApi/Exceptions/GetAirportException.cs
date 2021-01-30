using System;

namespace CTeleport.PlacesService.ApiClient.AirportsApi.Exceptions
{
    public sealed class GetAirportException : AirportsApiException
    {
        public GetAirportException(string message) : base(message) { }

        public GetAirportException(string message, Exception innerException) : base(message, innerException) { }
    }
}