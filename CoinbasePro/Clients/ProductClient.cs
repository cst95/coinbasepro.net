using System;
using System.Threading.Tasks;
using CoinbasePro.Http;

namespace CoinbasePro.Clients
{
    public class ProductClient : ApiClient, IProductClient
    {
        public ProductClient(IConnection connection)
            : base(connection)
        {}

        public async Task<object> GetProducts()
        {
            var url = new Uri("https://api.pro.coinbase.com/products");
            return await Connection.Get(url);
        }
    }
}
