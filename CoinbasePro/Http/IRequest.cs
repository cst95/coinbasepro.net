using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CoinbasePro.Http
{
    public interface IRequest
    {
        object Body { get; set; }
        Dictionary<string, string> Headers { get; set; }
        HttpMethod Method { get; set; }
        Uri BaseUrl { get; set; }
        Uri Endpoint { get; set; }
    }
}
