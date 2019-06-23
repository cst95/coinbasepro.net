using CoinbasePro.Http;

namespace CoinbasePro.Clients
{
    public abstract class ApiClient
    {
        protected ApiClient(IApiConnection apiConnection)
        {
            ApiConnection = apiConnection;
        }

        protected IApiConnection ApiConnection { get; private set; } 
    }
}
