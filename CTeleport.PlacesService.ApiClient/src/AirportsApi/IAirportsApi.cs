using System.Threading;
using System.Threading.Tasks;
using CTeleport.PlacesService.ApiClient.AirportsApi.ValueObjects;
using OneOf;

namespace CTeleport.PlacesService.ApiClient.AirportsApi
{
    /// <summary>
    /// Airports API interface
    /// </summary>
    public interface IAirportsApi
    {
        /// <summary>
        /// Fetches an airport by IATA code
        /// </summary>
        /// <returns>
        /// An Airport if airport is found, else AirportNotFound
        /// </returns>
        Task<OneOf<Airport, AirportNotFound>> GetAirport(string iataCode, CancellationToken ct);
    }
}