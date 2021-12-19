using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Application;
using OrderAPI.Domain.Models;
using OrderAPI.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // POST api/<OrderController>
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
