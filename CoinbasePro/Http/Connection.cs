using CoinbasePro.Authentication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Http
{
    public class Connection : IConnection
    {
        private readonly HttpClient _httpClient;

        public Connection(IAuthenticationHandler authenticationHandler)
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> Get(Uri uri)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri
            });
            
            return response;
        }

    }
}
