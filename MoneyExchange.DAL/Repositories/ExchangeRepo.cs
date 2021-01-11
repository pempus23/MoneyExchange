using MoneyExchange.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyExchange.DAL.Repository
{
    public class ExchangeRepo : BaseRepo<Exchange>
    {
        public override List<Exchange> GetAll()
        {
            return Context.Exchange.OrderBy(x => x.Id).ToList();
        }
        public override int Add(Exchange entity)
        {
            return base.Add(entity);
        }
    }
}
