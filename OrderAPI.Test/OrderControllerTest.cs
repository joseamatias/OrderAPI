using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OrderApi.Mappings;
using OrderAPI.Application;
using OrderAPI.Controllers;
using OrderAPI.Domain.Enums;
using OrderAPI.Models;
using System.Collections.Generic;

namespace OrderAPI.Test
{
    public class OrderControllerTests 
    {
        private OrderController _orderController;
        private Mock<IOrderService> _mockedOrderService;

        private OrderRequest orderTest = new OrderRequest()
        {
            OrderId = "order1",
            Items = new List<ItemsRequest>
            {
                new ItemsRequest{ Code = "ItemA1", Units = 6, PricePerUnit = 2.5, Type = TaxType.Type1 },
                new ItemsRequest{ Code = "ItemA2", Units = 12, PricePerUnit = 5, Type = TaxType.Type2 }
            }
        };

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            _mockedOrderService = new Mock<IOrderService>();
            _orderController = new OrderController(_mockedOrderService.Object, mapper);
        }
        
        [Test]
        public void Should_Return_Ok_When_Model_IsValid()
        {           
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Should_Return_BadRequest_When_OrderId_Lenght_IsNotValid()
        {
            orderTest.OrderId = "OrderIdMore10Characters";
            _orderController.ModelState.AddModelError("OrderId", "Length exceded");
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Should_Return_BadRequest_When_OrderId_IsEmpty()
        {
            orderTest.OrderId = string.Empty;
            _orderController.ModelState.AddModelError("OrderId", "Required");
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Should_Return_BadRequest_When_Code_Lenght_IsNotValid()
        {
            orderTest.Items[0].Code = "CodeMore10Characters";
            _orderController.ModelState.AddModelError("Code", "Length exceded");
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Should_Return_BadRequest_When_Code_IsEmpty()
        {
            orderTest.Items[0].Code = string.Empty;
            _orderController.ModelState.AddModelError("Code", "Required");
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Should_Return_BadRequest_When_Units_IsEmpty()
        {
            orderTest.Items[0] = new ItemsRequest { Code = "ItemA1", PricePerUnit = 2.5, Type = TaxType.Type1 };
            _orderController.ModelState.AddModelError("Units", "Required");
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Should_Return_BadRequest_When_Units_IsNegative()
        {
            orderTest.Items[0] = new ItemsRequest { Code = "ItemA1", Units = -6, PricePerUnit = 2.5, Type = TaxType.Type1 };
            _orderController.ModelState.AddModelError("Units", "Required");
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Should_Return_BadRequest_When_PricePerUnit_IsEmpty()
        {
            orderTest.Items[0] = new ItemsRequest { Code = "ItemA1", Units = 2, Type = TaxType.Type1 };
            _orderController.ModelState.AddModelError("PricePerUnit", "Required");
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Should_Return_BadRequest_When_PricePerUnit_More_Than_2_Decimals()
        {
            orderTest.Items[0] = new ItemsRequest { Code = "ItemA1", Units = 2, PricePerUnit = 2.5555, Type = TaxType.Type1 };
            _orderController.ModelState.AddModelError("PricePerUnit", "More than 2 decimals");
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Should_Return_Ok_When_Type_IsNotProvided()
        {
            orderTest.Items[0] = new ItemsRequest { Code = "ItemA1", Units = 6, PricePerUnit = 2.5 };            
            var result = _orderController.Post(orderTest);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

    }
}