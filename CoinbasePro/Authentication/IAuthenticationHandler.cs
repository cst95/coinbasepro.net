using CoinbasePro.Http;

namespace CoinbasePro.Authentication
{
    public interface IAuthenticationHandler
    {
        IRequest AddAuthenticationHeaders(IRequest request);
    }
}
