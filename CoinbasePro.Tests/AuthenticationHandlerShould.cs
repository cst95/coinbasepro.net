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
        [Fact]
        public void AddAccesKeyHeaderToRequest()
        {
            CheckRequestForHeader("CB-ACCESS-KEY");
        }

        [Fact]
        public void AddAccesSignatureHeaderToRequest()
        {
            CheckRequestForHeader("CB-ACCESS-SIGN");
        }

        [Fact]
        public void AddTimestampHeaderToRequest()
        {
            CheckRequestForHeader("CB-ACCESS-TIMESTAMP");
        }

        [Fact]
        public void AddPassphraseHeaderToRequest()
        {
            CheckRequestForHeader("CB-ACCESS-PASSPHRASE");
        }

        private void CheckRequestForHeader(string headerKey)
        {
            AuthenticationHandler sut = new AuthenticationHandler("test", "test", "test");
            Request request = new Request
            {
                Headers = new Dictionary<string, string>(),
                Endpoint = new Uri("/products", UriKind.Relative),
                Method = HttpMethod.Get
            };

            sut.AddAuthenticationHeadersToRequest(request);

            Assert.Contains(headerKey, request.Headers.Keys);
        }
    }
}
