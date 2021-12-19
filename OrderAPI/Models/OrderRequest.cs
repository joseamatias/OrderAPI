using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DTOs
{
    public class OrderRequest
    {
        [Required]
        [StringLength(10)]
        public string OrderId { get; set; }
        public List<ItemsRequest> Items { get; set; }

        public OrderRequest() {
            Items = new List<ItemsRequest>();
        }
    }
}
