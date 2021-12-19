using OrderAPI.Domain.Models;

namespace OrderAPI.Application
{
    public class OrderService : IOrderService
    {
        public Order TaxCalculation(Order order) 
        {
            foreach (var item in order.Items)
            {
                item.VatPercentaje = ((int)item.Type).Equals(2) ? 0 : 25;
                item.Subtotal = item.Units * item.PricePerUnit;
                item.TotalWithVat = item.Subtotal * (1 + item.VatPercentaje / 100);
                order.Total += item.TotalWithVat;
            }
            return order;
        }
    }
}
