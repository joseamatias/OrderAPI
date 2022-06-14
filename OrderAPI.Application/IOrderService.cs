using OrderAPI.Domain.Entities;

namespace OrderAPI.Application
{
    public interface IOrderService 
    {
        Order TaxCalculation(Order order);       
    }
}
