using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CoinbasePro.Http
{
    public interface IRequest
    {
        object Body { get; set; }
        HttpMethod Method { get; set; }
        Uri Endpoint { get; set; }
    }
}
