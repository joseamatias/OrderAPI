using System.Collections.Generic;

namespace OrderAPI.Models
{
    public class OrderResponse
    {        
        public string OrderId { get; set; }
        public List<ItemsResponse> Items { get; set; }
        public double Total { get; set; }
    }
}
