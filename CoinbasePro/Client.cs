using System;

namespace CoinbasePro
{
    public class Client
    {
        private readonly string _apiKey;
        private readonly string _passPhrase;

        public Client(string apiKey, string passPhrase)
        {
            _apiKey = apiKey;
            _passPhrase = passPhrase;
        }

        private long GenerateAccessTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
