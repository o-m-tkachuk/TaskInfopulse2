using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderRepository.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _orderRepository.GetOrder(id);
            if (order == null)
                return NotFound();
            return Ok(order);

        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            _orderRepository.Add(order);
            return CreatedAtAction(nameof(GetById),
                new { id = order.OrderId },
                order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Order order)
        {
            if (id != order.OrderId)
                return BadRequest();
            _orderRepository.Update(order);
            return Ok(order);
        }
    }
}
