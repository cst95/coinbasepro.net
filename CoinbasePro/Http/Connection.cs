using CoinbasePro.Authentication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Http
{
    public class Connection : IConnection
    {
        private readonly IHttpClient _httpClient;

        public Connection(IAuthenticationHandler authenticationHandler, Uri baseApiUrl)
        {
            _httpClient = new CustomHttpClient(authenticationHandler, baseApiUrl);
        }

        public Task<HttpResponseMessage> Get(IRequest request)
        {
            return _httpClient.SendAsync(request);
        }
    }
}
