using CoinbasePro.Http;
using System.Collections.Generic;

namespace CoinbasePro.Authentication
{
    public interface IAuthenticationHandler
    {
        Dictionary<string,string> GetAuthenticationHeadersForRequest(IRequest request);
    }
}
