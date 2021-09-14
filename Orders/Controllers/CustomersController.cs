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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerRepository.Get(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);

        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            //customer.CreatedDate = DateTime.Now.Date;
            _customerRepository.Add(customer);
            return CreatedAtAction(nameof(GetById),
                new { id = customer.CustomerId },
                customer);
        }
    }
}
