using CoinbasePro.Http;

namespace CoinbasePro.Clients
{
    public class ApiClient
    {
        protected ApiClient(IConnection connection)
        {
            Connection = connection;
        }

        protected IConnection Connection { get; private set; }
    }
}
