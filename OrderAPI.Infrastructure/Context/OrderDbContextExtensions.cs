using System.Collections.Generic;
using System.Linq;
using OrderAPI.Domain.Models;
using OrderAPI.Domain.Enums;

namespace OrderAPI.Infrastructure.Context
{
    public static class OrderDbContextExtensions
    {
        public static OrderDbContext SeedData(this OrderDbContext context)
        {
            if (context.Orders.Count() > 0)
                return context;

            var order1 = new Order()
            {
                OrderId = "NewOrder1",
                Items = new List<Items>
                {
                    new Items{ Code = "ItemA1", Units = 6, PricePerUnit = 2.5, Type = TaxType.Type1 },
                    new Items{ Code = "ItemA2", Units = 12, PricePerUnit = 5, Type = TaxType.Type2 }
                }
            };
            var order2 = new Order()
            {
                OrderId = "NewOrder2",
                Items = new List<Items>
                {
                    new Items{ Code = "ItemA3", Units = 5, PricePerUnit = 5.25, Type = TaxType.Type1 },
                    new Items{ Code = "ItemA4", Units = 1, PricePerUnit = 0.50, Type = TaxType.Type2 }
                }
            };

            var order3 = new Order()
            {
                OrderId = "NewOrder3",
                Items = new List<Items>
                {
                    new Items{ Code = "ItemA1", Units = 15, PricePerUnit = 1.5, Type = TaxType.Type1 },
                    new Items{ Code = "ItemA2", Units = 10, PricePerUnit = 3.5, Type = TaxType.Type2 }
                }
            };
            var orders = new List<Order> { order1, order2, order3 };

            context.Orders.AddRange(orders);

            context.SaveChanges();

            return context;
        }
    }
}
