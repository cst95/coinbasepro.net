using CoinbasePro.Http;

namespace CoinbasePro.Authentication
{
    public interface IAuthenticationHandler
    {
        void AddAuthenticationHeadersToRequest(IRequest request);
    }
}
