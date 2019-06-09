using System.Threading.Tasks;

namespace CoinbasePro.Clients
{
    public interface IProductClient
    {
        Task<object> GetProducts();
    }
}
