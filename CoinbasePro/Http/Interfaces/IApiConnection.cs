using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Http
{
    public interface IApiConnection
    {
        Task<HttpResponseMessage> Get(IRequest request);
    }
}
