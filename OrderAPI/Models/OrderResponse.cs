using OrderAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.DTOs
{
    public class OrderResponse
    {        
        public string OrderId { get; set; }
        public List<ItemsResponse> Items { get; set; }
        public double Total { get; set; }
    }
}
