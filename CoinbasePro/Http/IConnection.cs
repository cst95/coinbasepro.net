using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Http
{
    public interface IConnection
    {
        Task<HttpResponseMessage> Get(Uri uri);
    }
}
