using CoinbasePro.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public Dictionary<string, string> GetAuthenticationHeadersForRequest(IRequest request)
        {
            var headers = new Dictionary<string, string>();
            var timestamp = UnixTimestamp;

            headers = AddAccessKeyHeader(request, headers);
            headers = AddAccessPassphraseHeader(request, headers);
            headers = AddAccessSignHeader(request, timestamp, headers);
            headers = AddTimestampHeader(request, timestamp, headers);

            return headers;
        }

        private Dictionary<string,string> AddAccessSignHeader(IRequest request, long unixTimestamp, Dictionary<string,string> headers)
        {
            var hash = new HMACSHA256(HmacKey);
            var preHashMessage = CalculatePreHashMessage(request, unixTimestamp);
            var base64EncodedHash = Convert.ToBase64String(hash.ComputeHash(preHashMessage));

            headers.Add(key: "CB-ACCESS-SIGN", value: base64EncodedHash);
            return headers;
        }

        private Dictionary<string, string> AddAccessPassphraseHeader(IRequest request, Dictionary<string, string> headers)
        {
            headers.Add(key: "CB-ACCESS-PASSPHRASE", value: _passphrase);
            return headers;
        }

        private Dictionary<string, string> AddTimestampHeader(IRequest request, long unixTimestamp, Dictionary<string, string> headers)
        {
            var timestamp = unixTimestamp.ToString();

            headers.Add(key: "CB-ACCESS-TIMESTAMP", value: timestamp);
            return headers;
        }

        private Dictionary<string, string> AddAccessKeyHeader(IRequest request, Dictionary<string, string> headers)
        {
            headers.Add(key: "CB-ACCESS-KEY", value: _apikey);
            return headers;
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
    }
}
