using AutoMapper;
using NUnit.Framework;
using OrderApi.Mappings;
using OrderAPI.Application;
using OrderAPI.Domain.Enums;
using OrderAPI.Domain.Models;
using System.Collections.Generic;

namespace OrderAPI.Test
{
    public class OrderServiceTests
    {
        
        private IOrderService _orderService;

        private Order orderTest = new Order()
        {
            OrderId = "NewOrder",
            Items = new List<Items>
            {
                new Items{ Code = "ItemA1", Units = 6, PricePerUnit = 2.5, Type = TaxType.Type1 },
                new Items{ Code = "ItemA2", Units = 12, PricePerUnit = 5, Type = TaxType.Type2 }
            }
        };

        [SetUp]
        public void Setup()
        {
            _orderService = new OrderService();            
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();            
        }
        

        [Test]
        public void Should_Return_Total_TaxCalculation_Ok() 
        {
            var result = _orderService.TaxCalculation(orderTest);
            Assert.IsNotNull(result);
            Assert.AreEqual(78.75, result.Total);
        }

        [Test]
        public void Should_Return_Total_TaxCalculation_Ok_When_Type_IsNotProvided()
        {
            var order = new Order()
            {
                OrderId = "NewOrder",
                Items = new List<Items>{
                    new Items{ Code = "ItemA1", Units = 6, PricePerUnit = 2.5 },
                    new Items{ Code = "ItemA2", Units = 12, PricePerUnit = 5, Type = TaxType.Type2 }
                }
            };
            var result = _orderService.TaxCalculation(order);
            Assert.IsNotNull(result);
            Assert.AreEqual(TaxType.Type1, result.Items[0].Type);
            Assert.AreEqual(78.75, result.Total);
        }       
    }
}