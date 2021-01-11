using MoneyExchange.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace MoneyExchange.BLL.ExchangeService
{
    public class HttpRequestService : IHttpRequestService
    {
        public CurrencyResponse Request(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            CurrencyResponse Response = JsonConvert.DeserializeObject<CurrencyResponse>(response);
            return Response;
        }
    }
}
