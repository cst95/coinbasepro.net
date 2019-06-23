using CoinbasePro.Http;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

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

        public void AddAuthenticationHeadersToRequest(IRequest request)
        {
            var timestamp = UnixTimestamp;

            AddAccessKeyHeaderToRequest(request);
            AddAccessPassphraseHeaderToRequest(request);
            AddTimestampHeaderToRequest(request, timestamp);
            AddAccessSignHeaderToRequest(request, timestamp);
        }

        private long UnixTimestamp
        {
            get => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        private byte[] HmacKey
        {
            get
            {
                string hmacKey = Base64DecodeSecret(_secret);
                return Encoding.UTF8.GetBytes(hmacKey);
            }
        }

        private string Base64DecodeSecret(string secret)
        {
            byte[] data = Convert.FromBase64String(_secret);
            return Encoding.UTF8.GetString(data);
        }

        private byte[] CalculatePreHashMessage(IRequest request, long unixTimestamp)
        {
            string timestamp = unixTimestamp.ToString();
            string requestPath = request.Endpoint.ToString();
            string method = request.Method.ToString().ToUpper();
            string body = request.Body != null ? JsonConvert.SerializeObject(request.Body) : string.Empty;

            string preHashString = timestamp + method + requestPath + body;

            return Encoding.UTF8.GetBytes(preHashString);
        }

        private void AddAccessKeyHeaderToRequest(IRequest request)
        {
            request.Headers.Add(key: "CB-ACCESS-KEY", value: _apikey);
        }

        private void AddAccessSignHeaderToRequest(IRequest request, long unixTimestamp)
        {
            var hash = new HMACSHA256(HmacKey);
            var preHashMessage = CalculatePreHashMessage(request, unixTimestamp);
            var base64EncodedHash = Convert.ToBase64String(hash.ComputeHash(preHashMessage));

            request.Headers.Add("CB-ACCESS-SIGN", base64EncodedHash);
        }

        private void AddAccessPassphraseHeaderToRequest(IRequest request)
        {
            request.Headers.Add("CB-ACCESS-PASSPHRASE", _passphrase);
        }

        private void AddTimestampHeaderToRequest(IRequest request, long unixTimestamp)
        {
            var timestamp = unixTimestamp.ToString();

            request.Headers.Add("CB-ACCESS-TIMESTAMP", timestamp);
        }
    }
}
