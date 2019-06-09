using CoinbasePro.Http;

namespace CoinbasePro.Authentication
{
    public class AuthenticationHandler : IAuthenticationHandler
    {
        private readonly string _apikey;
        private readonly string _passphrase;
        private readonly string _secret;

        public AuthenticationHandler(string apiKey, string passphrase, string secret)
        {
            _apikey = apiKey;
            _passphrase = passphrase;
            _secret = secret;
        }

        public IRequest AddAuthenticationHeaders(IRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
