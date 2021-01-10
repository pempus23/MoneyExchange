using MoneyExchange.DAL.Repository.Templates;
using MoneyExchange.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace MoneyExchange.BLL.ExchangeService
{
    public class ExchangeService : IExchangeService
    {
        private readonly IRepo<Exchange> _repository;
        public ExchangeService(IRepo<Exchange> repository)
        {
            _repository = repository;
        }
        public int ExchangeRate(Exchange entity)
        {
            if (entity.FromAmount != 0)
            {
                string url = "https://api.exchangeratesapi.io/latest?base=";

                switch (entity.FromCurrency)
                {
                    case Currency.USD:
                        url += "USD";
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        string response;
                        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            response = streamReader.ReadToEnd();
                        }
                        CurrencyResponse Response = JsonConvert.DeserializeObject<CurrencyResponse>(response);
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
                        HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse httpWebResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
                        string response2;
                        using (StreamReader streamReader = new StreamReader(httpWebResponse2.GetResponseStream()))
                        {
                            response2 = streamReader.ReadToEnd();
                        }
                        CurrencyResponse Response2 = JsonConvert.DeserializeObject<CurrencyResponse>(response2);
                        switch (entity.ToCurrency)
                        {
                            case Currency.USD:
                                entity.ToAmount = entity.FromAmount * Response2.rates.USD;
                                break;
                            case Currency.GBP:
                                entity.ToAmount = entity.FromAmount * Response2.rates.GBP;
                                break;
                            case Currency.CHF:
                                entity.ToAmount = entity.FromAmount * Response2.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.GBP:
                        url += "GBP";
                        HttpWebRequest httpWebRequest3 = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse httpWebResponse3 = (HttpWebResponse)httpWebRequest3.GetResponse();
                        string response3;
                        using (StreamReader streamReader = new StreamReader(httpWebResponse3.GetResponseStream()))
                        {
                            response3 = streamReader.ReadToEnd();
                        }
                        CurrencyResponse Response3 = JsonConvert.DeserializeObject<CurrencyResponse>(response3);
                        switch (entity.ToCurrency)
                        {
                            case Currency.EUR:
                                entity.ToAmount = entity.FromAmount * Response3.rates.EUR;
                                break;
                            case Currency.USD:
                                entity.ToAmount = entity.FromAmount * Response3.rates.USD;
                                break;
                            case Currency.CHF:
                                entity.ToAmount = entity.FromAmount * Response3.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.CHF:
                        url += "CHF";
                        HttpWebRequest httpWebRequest4 = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse httpWebResponse4 = (HttpWebResponse)httpWebRequest4.GetResponse();
                        string response4;
                        using (StreamReader streamReader = new StreamReader(httpWebResponse4.GetResponseStream()))
                        {
                            response4 = streamReader.ReadToEnd();
                        }
                        CurrencyResponse Response4 = JsonConvert.DeserializeObject<CurrencyResponse>(response4);
                        switch (entity.ToCurrency)
                        {
                            case Currency.EUR:
                                entity.ToAmount = entity.FromAmount * Response4.rates.EUR;
                                break;
                            case Currency.GBP:
                                entity.ToAmount = entity.FromAmount * Response4.rates.GBP;
                                break;
                            case Currency.USD:
                                entity.ToAmount = entity.FromAmount * Response4.rates.USD;
                                break;
                        }
                        break;
                }
            }
            else
            {
                string url = "https://api.exchangeratesapi.io/latest?base=";

                switch (entity.ToCurrency)
                {
                    case Currency.USD:
                        url += "USD";
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        string response;
                        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            response = streamReader.ReadToEnd();
                        }
                        CurrencyResponse Response = JsonConvert.DeserializeObject<CurrencyResponse>(response);
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
                        HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse httpWebResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
                        string response2;
                        using (StreamReader streamReader = new StreamReader(httpWebResponse2.GetResponseStream()))
                        {
                            response2 = streamReader.ReadToEnd();
                        }
                        CurrencyResponse Response2 = JsonConvert.DeserializeObject<CurrencyResponse>(response2);
                        switch (entity.FromCurrency)
                        {
                            case Currency.USD:
                                entity.FromAmount = entity.ToAmount * Response2.rates.USD;
                                break;
                            case Currency.GBP:
                                entity.FromAmount = entity.ToAmount * Response2.rates.GBP;
                                break;
                            case Currency.CHF:
                                entity.FromAmount = entity.ToAmount * Response2.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.GBP:
                        url += "GBP";
                        HttpWebRequest httpWebRequest3 = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse httpWebResponse3 = (HttpWebResponse)httpWebRequest3.GetResponse();
                        string response3;
                        using (StreamReader streamReader = new StreamReader(httpWebResponse3.GetResponseStream()))
                        {
                            response3 = streamReader.ReadToEnd();
                        }
                        CurrencyResponse Response3 = JsonConvert.DeserializeObject<CurrencyResponse>(response3);
                        switch (entity.FromCurrency)
                        {
                            case Currency.EUR:
                                entity.FromAmount = entity.ToAmount * Response3.rates.EUR;
                                break;
                            case Currency.USD:
                                entity.FromAmount = entity.ToAmount * Response3.rates.USD;
                                break;
                            case Currency.CHF:
                                entity.FromAmount = entity.ToAmount * Response3.rates.CHF;
                                break;
                        }
                        break;
                    case Currency.CHF:
                        url += "CHF";
                        HttpWebRequest httpWebRequest4 = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse httpWebResponse4 = (HttpWebResponse)httpWebRequest4.GetResponse();
                        string response4;
                        using (StreamReader streamReader = new StreamReader(httpWebResponse4.GetResponseStream()))
                        {
                            response4 = streamReader.ReadToEnd();
                        }
                        CurrencyResponse Response4 = JsonConvert.DeserializeObject<CurrencyResponse>(response4);
                        switch (entity.FromCurrency)
                        {
                            case Currency.EUR:
                                entity.FromAmount = entity.ToAmount * Response4.rates.EUR;
                                break;
                            case Currency.GBP:
                                entity.FromAmount = entity.ToAmount * Response4.rates.GBP;
                                break;
                            case Currency.USD:
                                entity.FromAmount = entity.ToAmount * Response4.rates.USD;
                                break;
                        }
                        break;
                }
            }
            return _repository.Add(entity);
        }
    }
}
