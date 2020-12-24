using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyExchange.Models
{
    public class Exchange
    {
        [Key]
        public int id { get; set; }
        public decimal FromCurrency { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToCurrency { get; set; }
        public decimal ToAmount { get; set; }
        public DateTime Date { get; set; }

    }
}
