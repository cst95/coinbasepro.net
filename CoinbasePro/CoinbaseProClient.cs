using CoinbasePro.Authentication;
using CoinbasePro.Clients;
using CoinbasePro.Http;
using System;

namespace CoinbasePro
{
    public class CoinbaseProClient
    {
        public static readonly Uri CoinbaseProApiUrl = new Uri("https://api.pro.coinbase.com");
        public static readonly Uri CoinbaseProApiSandboxUrl = new Uri("https://api-public.sandbox.pro.coinbase.com");


        public CoinbaseProClient(IAuthenticationHandler authenticationHandler, bool testing = false)
        {
            var apiUrl = testing ? CoinbaseProApiSandboxUrl : CoinbaseProApiUrl;

            IConnection connection = new Connection(authenticationHandler, apiUrl);
            IApiConnection apiConnection = new ApiConnection(connection); 

            Products = new ProductClient(apiConnection);
        }


        public IApiConnection ApiConnection { get; set; }
        public IProductClient Products { get; set; }
    }
}
