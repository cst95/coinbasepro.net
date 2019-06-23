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

        public Task<HttpResponseMessage> GetProductsAsync()
        {
            var request = new Request
            {
                Method = HttpMethod.Get,
                Endpoint = new Uri("/products", UriKind.Relative)
            };


            return ApiConnection.Get(request);
        }
    }
}
