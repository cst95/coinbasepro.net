using CoinbasePro.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Http
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthenticationHandler _authenticationHandler;

        public CustomHttpClient(IAuthenticationHandler authHandler, Uri baseApiUrl)
        {
            _httpClient = new HttpClient();
            _authenticationHandler = authHandler;

            _httpClient.BaseAddress = baseApiUrl;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "CoinbasePro.NET Client");
        }

        public Task<HttpResponseMessage> SendAsync(IRequest request)
        {
            var httpRequest = CreateHttpRequest(request);

            return _httpClient.SendAsync(httpRequest);
        }

        private HttpRequestMessage CreateHttpRequest(IRequest request)
        {
            var httpRequest = new HttpRequestMessage(request.Method, request.Endpoint);
            var authHeadersToAdd = _authenticationHandler.GetAuthenticationHeadersForRequest(request);

            foreach (KeyValuePair<string, string> header in authHeadersToAdd)
            {
                httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return httpRequest;
        }
    }
}
