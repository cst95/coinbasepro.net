using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CoinbasePro.Http
{
    public class Request : IRequest
    {
        public object Body { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public HttpMethod Method { get; set; }
        public Uri BaseUrl { get; set; }
        public Uri Endpoint { get; set; }
    }
}
