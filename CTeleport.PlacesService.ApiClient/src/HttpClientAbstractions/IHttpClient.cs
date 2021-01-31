using System.Threading;
using System.Threading.Tasks;

namespace CTeleport.PlacesService.ApiClient.HttpClientAbstractions
{
    /// <summary>
    /// Generic HTTP client interface
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Returns parsed object from JSON response
        /// </summary>
        Task<TValue?> GetFromJsonAsync<TValue>(string? requestUri, CancellationToken cancellationToken = default);
    }
}