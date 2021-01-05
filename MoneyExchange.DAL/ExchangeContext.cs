using Microsoft.EntityFrameworkCore;
using MoneyExchange.Models;

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

        public ExchangeContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MoneyExchange;Trusted_Connection=True;");
    }
}
