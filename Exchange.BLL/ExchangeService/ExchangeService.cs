using MoneyExchange.DAL.Repository.Templates;
using MoneyExchange.Models;

namespace MoneyExchange.BLL.ExchangeService
{
    public class ExchangeService : IExchangeService
    {
        private string url = "https://api.exchangeratesapi.io/latest?base=";
        private readonly IRepo<Exchange> _repository;
        private IHttpRequestService _reqestService;
        public ExchangeService(IRepo<Exchange> repository, IHttpRequestService requestService)
        {
            _repository = repository;
            _reqestService = requestService;
        }
        public int ExchangeRate(Exchange entity)
        {
            CurrencyResponse Response = new CurrencyResponse();
            if (entity.FromAmount != 0)
            {
                switch (entity.FromCurrency)
                {
                    case Currency.USD:
                        url += "USD";
                        Response = _reqestService.Request(url);
                        switch (entity.ToCurrency)
                        {
                            case Currency.EUR:
                                entity.ToAmount = entity.FromAmount * Response.rates.EUR;
                                break;
                            case Currency.GBP:
                                entity.ToAmount = entity.FromAmount * Response.rates.GBP;
                                break;
                            case Currency.CHF:
                                entity.ToAmount = entity.FromAmount * Response.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.EUR:
                        url += "EUR";
                        Response = _reqestService.Request(url);
                        switch (entity.ToCurrency)
                        {
                            case Currency.USD:
                                entity.ToAmount = entity.FromAmount * Response.rates.USD;
                                break;
                            case Currency.GBP:
                                entity.ToAmount = entity.FromAmount * Response.rates.GBP;
                                break;
                            case Currency.CHF:
                                entity.ToAmount = entity.FromAmount * Response.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.GBP:
                        url += "GBP";
                        Response = _reqestService.Request(url);
                        switch (entity.ToCurrency)
                        {
                            case Currency.EUR:
                                entity.ToAmount = entity.FromAmount * Response.rates.EUR;
                                break;
                            case Currency.USD:
                                entity.ToAmount = entity.FromAmount * Response.rates.USD;
                                break;
                            case Currency.CHF:
                                entity.ToAmount = entity.FromAmount * Response.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.CHF:
                        url += "CHF";
                        Response = _reqestService.Request(url);
                        switch (entity.ToCurrency)
                        {
                            case Currency.EUR:
                                entity.ToAmount = entity.FromAmount * Response.rates.EUR;
                                break;
                            case Currency.GBP:
                                entity.ToAmount = entity.FromAmount * Response.rates.GBP;
                                break;
                            case Currency.USD:
                                entity.ToAmount = entity.FromAmount * Response.rates.USD;
                                break;
                        }
                        break;
                }
            }
            else
            {
                switch (entity.ToCurrency)
                {
                    case Currency.USD:
                        url += "USD";
                        Response = _reqestService.Request(url);
                        switch (entity.FromCurrency)
                        {
                            case Currency.EUR:
                                entity.FromAmount = entity.ToAmount * Response.rates.EUR;
                                break;
                            case Currency.GBP:
                                entity.FromAmount = entity.ToAmount * Response.rates.GBP;
                                break;
                            case Currency.CHF:
                                entity.FromAmount = entity.ToAmount * Response.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.EUR:
                        url += "EUR";
                        Response = _reqestService.Request(url);
                        switch (entity.FromCurrency)
                        {
                            case Currency.USD:
                                entity.FromAmount = entity.ToAmount * Response.rates.USD;
                                break;
                            case Currency.GBP:
                                entity.FromAmount = entity.ToAmount * Response.rates.GBP;
                                break;
                            case Currency.CHF:
                                entity.FromAmount = entity.ToAmount * Response.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.GBP:
                        url += "GBP";
                        Response = _reqestService.Request(url);
                        switch (entity.FromCurrency)
                        {
                            case Currency.EUR:
                                entity.FromAmount = entity.ToAmount * Response.rates.EUR;
                                break;
                            case Currency.USD:
                                entity.FromAmount = entity.ToAmount * Response.rates.USD;
                                break;
                            case Currency.CHF:
                                entity.FromAmount = entity.ToAmount * Response.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.CHF:
                        url += "CHF";
                        Response = _reqestService.Request(url);
                        switch (entity.FromCurrency)
                        {
                            case Currency.EUR:
                                entity.FromAmount = entity.ToAmount * Response.rates.EUR;
                                break;
                            case Currency.GBP:
                                entity.FromAmount = entity.ToAmount * Response.rates.GBP;
                                break;
                            case Currency.USD:
                                entity.FromAmount = entity.ToAmount * Response.rates.USD;
                                break;
                        }
                        break;
                }
            }
            return _repository.Add(entity);
        }
    }
}
