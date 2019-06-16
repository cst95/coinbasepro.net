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

        private readonly AuthenticationHandler _subjectUnderTest;
        private readonly Request _request;


        public AuthenticationHandlerShould()
        {
            _subjectUnderTest = new AuthenticationHandler("test", "test", "test");

            _request = new Request
            {
                Headers = new Dictionary<string, string>(),
                Endpoint = new Uri("/products", UriKind.Relative),
                Method = HttpMethod.Get
            };

            _subjectUnderTest.AddAuthenticationHeadersToRequest(_request);
        }

        [Fact]
        public void AddAccesKeyHeaderToRequest()
        {
            Assert.Contains("CB-ACCESS-KEY", _request.Headers.Keys);
        }

        [Fact]
        public void AddAccesSignatureHeaderToRequest()
        {
            Assert.Contains("CB-ACCESS-SIGN", _request.Headers.Keys);
        }

        [Fact]
        public void AddTimestampHeaderToRequest()
        {
            Assert.Contains("CB-ACCESS-TIMESTAMP", _request.Headers.Keys);
        }

        [Fact]
        public void AddPassphraseHeaderToRequest()
        {
            Assert.Contains("CB-ACCESS-PASSPHRASE", _request.Headers.Keys);
        }
    }
}
