using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyExchange.DAL;
using MoneyExchange.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MoneyExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly ExchangeContext db;
        public ExchangeController(ExchangeContext context)
        {
            db = context;
            if (!db.Exchange.Any())
            {
                db.Exchange.AddRange(
                    new Exchange { FromAmount = 12, ToAmount = 2, FromCurrency = Currency.EUR, ToCurrency = Currency.USD, Date = DateTime.Now },
                    new Exchange { FromAmount = 10, ToAmount = 20, FromCurrency = Currency.EUR, ToCurrency = Currency.CHF, Date = DateTime.Now },
                    new Exchange { FromAmount = 1, ToAmount = 14, FromCurrency = Currency.GBP, ToCurrency = Currency.EUR, Date = DateTime.Now }
                    );
                db.SaveChanges();
            }


            string url = "https://api.exchangeratesapi.io/latest?base=USD";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            CurrencyResponse Response = JsonConvert.DeserializeObject<CurrencyResponse>(response);
          
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exchange>>> Get()
        {
            return await db.Exchange.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exchange>> Get(int id)
        {
            Exchange exchange = await db.Exchange.FirstOrDefaultAsync(x => x.id == id);
            if (exchange == null)
                return NotFound();
            return new ObjectResult(exchange);
        }

        [HttpPost]
        public async Task<ActionResult<Exchange>> Post(Exchange exchange)
        {
            if (exchange == null)
            {
                return BadRequest();
            }
            exchange.Date = DateTime.Now;
            db.Exchange.Add(exchange);
            await db.SaveChangesAsync();
            return Ok(exchange);
        }
    }
}
