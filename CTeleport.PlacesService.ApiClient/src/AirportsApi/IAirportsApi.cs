using System.Threading;
using System.Threading.Tasks;
using CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects;
using OneOf;

namespace CTeleport.PlacesService.ApiClient.AirportsApi
{
    public interface IAirportsApi
    {
        Task<OneOf<Airport, AirportNotFound>> GetAirport(string iataCode, CancellationToken ct);
    }
}