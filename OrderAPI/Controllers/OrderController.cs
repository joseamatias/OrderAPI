using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Application;
using OrderAPI.Domain.Entities;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <summary>
        /// Method to calculate tax
        /// </summary>
        /// <param name="orderRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] OrderRequest orderRequest)
        {
            if (!ModelState.IsValid) {
                return BadRequest("Validation error");
            }

            var order = _mapper.Map<Order>(orderRequest);
            var result = _orderService.TaxCalculation(order);
            return Ok(result);
        }        
    }
}
