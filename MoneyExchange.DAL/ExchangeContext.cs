using Microsoft.EntityFrameworkCore;
using MoneyExchange.Models;
using System;

namespace MoneyExchange.DAL
{
    public class ExchangeContext : DbContext
    {
        public DbSet<Exchange> Exchange { get; set; }
        public ExchangeContext(DbContextOptions<ExchangeContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
