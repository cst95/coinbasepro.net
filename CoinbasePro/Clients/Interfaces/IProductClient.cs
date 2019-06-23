using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Clients
{
    public interface IProductClient
    {
        Task<HttpResponseMessage> GetProductsAsync();
    }
}
