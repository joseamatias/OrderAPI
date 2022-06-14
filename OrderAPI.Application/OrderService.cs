
using OrderAPI.Domain.Entities;

namespace OrderAPI.Application
{
    public class OrderService : IOrderService
    {
        public Order TaxCalculation(Order order) 
        {
            foreach (var item in order.Items)
            {
                item.Subtotal = item.Units * item.PricePerUnit;
                order.Total += item.TotalWithVat;
            }
            return order;
        }
    }
}
