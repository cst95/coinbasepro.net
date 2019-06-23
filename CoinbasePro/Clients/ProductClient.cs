using System;
using System.Threading.Tasks;
using CoinbasePro.Http;

namespace CoinbasePro.Clients
{
    public class ProductClient : ApiClient, IProductClient
    {
        public ProductClient(IApiConnection apiConnection)
            : base(apiConnection)
        {}

        public async Task<object> GetProducts()
        {
            var url = new Uri("https://api.pro.coinbase.com/products");
            return await ApiConnection.Get(url);
        }
    }
}
