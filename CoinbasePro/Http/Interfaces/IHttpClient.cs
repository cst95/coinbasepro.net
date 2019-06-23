using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Http
{
    interface IHttpClient
    {
        Task<HttpResponseMessage> SendAsync(IRequest request);
    }
}
