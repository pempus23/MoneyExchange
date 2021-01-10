using MoneyExchange.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

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
