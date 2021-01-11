using MoneyExchange.Models;

namespace MoneyExchange.BLL.ExchangeService
{
    public interface IHttpRequestService
    {
        CurrencyResponse Request(string url);
    }
}
