using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoinbasePro.Http;

namespace CoinbasePro.Clients
{
    public class ProductClient : ApiClient, IProductClient
    {
        public ProductClient(IApiConnection apiConnection)
            : base(apiConnection)
        {}

        public Task<HttpResponseMessage> GetProducts()
        {
            var endpoint = new Uri("/products", UriKind.Relative);

            return ApiConnection.Get(endpoint);
        }
    }
}
