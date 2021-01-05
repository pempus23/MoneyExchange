using MoneyExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyExchange.DAL.Repository
{
    public class ExchangeRepo : BaseRepo<Exchange>
    {
        public override List<Exchange> GetAll()
        {
            return Context.Exchange.OrderBy(x => x.Id).ToList();
        }
    }
}
