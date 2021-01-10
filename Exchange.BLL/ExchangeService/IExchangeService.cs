using MoneyExchange.Models;

namespace MoneyExchange.BLL.ExchangeService
{
    public interface IExchangeService
    {
        int ExchangeRate(Exchange item);
    }
}
