using CoinbasePro.Authentication;
using CoinbasePro.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace CoinbasePro.Tests
{
    public class AuthenticationHandlerShould
    {
        private readonly Dictionary<string, string> _authHeadersCreatedByAuthHandler;

        public AuthenticationHandlerShould()
        {
            var subjectUnderTest = new AuthenticationHandler("test", "test", "test");

            var request = new Request
            {
                Endpoint = new Uri("/products", UriKind.Relative),
                Method = HttpMethod.Get
            };

            _authHeadersCreatedByAuthHandler = subjectUnderTest.GetAuthenticationHeadersForRequest(request);
        }

        [Fact]
        public void AddAccesKeyHeaderToRequest()
        {
            Assert.Contains("CB-ACCESS-KEY", _authHeadersCreatedByAuthHandler.Keys);
        }

        [Fact]
        public void AddAccesSignatureHeaderToRequest()
        {
            Assert.Contains("CB-ACCESS-SIGN", _authHeadersCreatedByAuthHandler.Keys);
        }

        [Fact]
        public void AddTimestampHeaderToRequest()
        {
            Assert.Contains("CB-ACCESS-TIMESTAMP", _authHeadersCreatedByAuthHandler.Keys);
        }

        [Fact]
        public void AddPassphraseHeaderToRequest()
        {
            Assert.Contains("CB-ACCESS-PASSPHRASE", _authHeadersCreatedByAuthHandler.Keys);
        }
    }
}
