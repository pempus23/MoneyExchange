using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyExchange.DAL;
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
        ExchangeContext db;
        public ExchangeController(ExchangeContext context)
        {
            db = context;
            if (!db.Exchange.Any())
            {
                db.Exchange.Add(new Exchange { FromAmount = 12, ToAmount = 2, FromCurrency = 2, ToCurrency = 2, Date = DateTime.Now });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exchange>>> Get()
        {
            return await db.Exchange.ToListAsync();
        }
    }
}
