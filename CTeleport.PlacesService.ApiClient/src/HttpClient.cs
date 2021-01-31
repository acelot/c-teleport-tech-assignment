using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using CTeleport.PlacesService.ApiClient.HttpClientAbstractions;

namespace CTeleport.PlacesService.ApiClient
{
    /// <summary>
    /// IHttpClient implementation
    /// </summary>
    public sealed class HttpClient: IHttpClient
    {
        private readonly System.Net.Http.HttpClient _internalHttpClient;

        /// <summary>
        /// HttpClient constructor
        /// </summary>
        public HttpClient(System.Net.Http.HttpClient internalHttpClient)
        {
            this._internalHttpClient = internalHttpClient;
        }

        /// <inheritdoc/>
        public Task<TValue?> GetFromJsonAsync<TValue>(string? requestUri, CancellationToken cancellationToken = default)
        {
            return this._internalHttpClient.GetFromJsonAsync<TValue>(requestUri, cancellationToken);
        }
    }
}