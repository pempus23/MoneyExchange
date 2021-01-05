﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyExchange.DAL;
using MoneyExchange.DAL.Repository.Templates;
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
        private readonly IRepo<Exchange> _repository;
        public ExchangeController(IRepo<Exchange> repository, ExchangeContext context)
        {
            db = context;
            _repository = repository;
            if (!db.Exchange.Any())
                db.Exchange.AddRange(
                    new Exchange { FromAmount = 12.22M, ToAmount = 2.22M, FromCurrency = Currency.EUR, ToCurrency = Currency.USD, Date = DateTime.Now },
                    new Exchange { FromAmount = 10.22M, ToAmount = 20.22M, FromCurrency = Currency.EUR, ToCurrency = Currency.CHF, Date = DateTime.Now },
                    new Exchange { FromAmount = 12.22M, ToAmount = 142.22M, FromCurrency = Currency.GBP, ToCurrency = Currency.EUR, Date = DateTime.Now }
                    );
            db.SaveChanges();




            //string url = "https://api.exchangeratesapi.io/latest?base=USD";
            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //string response;
            //using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            //{
            //    response = streamReader.ReadToEnd();
            //}
            //CurrencyResponse Response = JsonConvert.DeserializeObject<CurrencyResponse>(response);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exchange>>> Get()
        {
            return _repository.GetAll();
            //return await db.Exchange.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Exchange>> Post(Exchange exchange)
        {
            if (exchange == null)
            {
                return BadRequest();
            }
            exchange.Date = DateTime.Now;
            _repository.Add(exchange);
            return Ok(exchange);
        }
    }
}
