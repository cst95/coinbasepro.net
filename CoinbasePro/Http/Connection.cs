using CoinbasePro.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Http
{
    public class Connection : IConnection
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseApiUrl;
        private readonly IAuthenticationHandler _authenticationHandler;

        public Connection(IAuthenticationHandler authenticationHandler, Uri baseApiUri)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseApiUri;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Framework Test Client");
            _authenticationHandler = authenticationHandler;
        }

        public async Task<HttpResponseMessage> Get(Uri endpoint)
        {
            var request = new Request
            {
                Method = HttpMethod.Get,
                BaseUrl = _baseApiUrl,
                Endpoint = endpoint,
                Headers = new Dictionary<string, string>()
            };

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, request.Endpoint);

            var response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);

            return response;


        }
    }
}
