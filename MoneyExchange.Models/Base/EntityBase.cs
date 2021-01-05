using System.ComponentModel.DataAnnotations;

namespace MoneyExchange.Models.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
