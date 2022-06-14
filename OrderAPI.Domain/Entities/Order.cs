using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Domain.Entities
{
    public class Order
    {
        [Required]
        [StringLength(10)]
        public string OrderId { get; set; }
        public List<Items> Items { get; set; }
        public double Total { get; set; }

        public Order()
        {
            Items = new List<Items>();
        }
    }

   
}
