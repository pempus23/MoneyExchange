using Microsoft.AspNetCore.Mvc;
using MoneyExchange.BLL.ExchangeService;
using MoneyExchange.DAL;
using MoneyExchange.DAL.Repository.Templates;
using MoneyExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly ExchangeContext db;
        private readonly IRepo<Exchange> _repository;
        private readonly IExchangeService _service;
        public ExchangeController(IRepo<Exchange> repository, ExchangeContext context, IExchangeService service)
        {
            _service = service;
            db = context;
            _repository = repository;
            if (!db.Exchange.Any())
                db.Exchange.AddRange(
                    new Exchange { FromAmount = 12.22M, ToAmount = 2.22M, FromCurrency = Currency.EUR, ToCurrency = Currency.USD, Date = DateTime.Now },
                    new Exchange { FromAmount = 10.22M, ToAmount = 20.22M, FromCurrency = Currency.EUR, ToCurrency = Currency.CHF, Date = DateTime.Now },
                    new Exchange { FromAmount = 12.22M, ToAmount = 142.22M, FromCurrency = Currency.GBP, ToCurrency = Currency.EUR, Date = DateTime.Now }
                    );
            db.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exchange>>> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Exchange>> Post(Exchange exchange)
        {
            if (exchange == null)
            {
                return BadRequest();
            }
            exchange.Date = DateTime.Now;
            _service.ExchangeRate(exchange);
            return Ok(exchange);
        }
    }
}
