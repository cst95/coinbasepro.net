using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbasePro.Http
{
    public class ApiConnection : IApiConnection
    {
        public ApiConnection(IConnection connection)
        {
            Connection = connection;
        }

        public IConnection Connection { get; private set; }

        public Task<HttpResponseMessage> Get(Uri uri)
        {
            return Connection.Get(uri);
        }

    }
}
