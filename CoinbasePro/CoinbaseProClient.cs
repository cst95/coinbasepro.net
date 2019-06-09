using CoinbasePro.Authentication;
using CoinbasePro.Clients;
using CoinbasePro.Http;

namespace CoinbasePro
{
    public class CoinbaseProClient
    {

        public CoinbaseProClient(IAuthenticationHandler authenticationHandler)
            : this(new Connection(authenticationHandler))
        {}

        public CoinbaseProClient(IConnection connection)
        {
            Products = new ProductClient(connection);
        }

        public IProductClient Products { get; set; }
    }
}
