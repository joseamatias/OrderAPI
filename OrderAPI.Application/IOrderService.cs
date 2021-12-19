using OrderAPI.Domain.Models;

namespace OrderAPI.Application
{
    public interface IOrderService 
    {
        Order TaxCalculation(Order order);       
    }
}
