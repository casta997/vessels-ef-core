using CarRentalApplication.Entities;
using CarRentalApplication.Request;
using CarRentalApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController(CustomerService customerService) : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{customerId:long}")]
        public IActionResult GetById(long customerId)
        {
            var customer = customerService.GetById(customerId);
            return Ok(customer);
        }

        [HttpPost("create customer")]
        public IActionResult CreateObj([FromBody] CustomerRequest request)
        {
            customerService.CreateObj(request.Name);
            return Ok();
        }

        [HttpPut("{id}/{name}")]
        public IActionResult UpdateObj(long id, string name)
        {
            customerService.UpdateObj(id, name);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteObj(long id)
        {
            customerService.DeleteObj(id);
            return Ok();
        }
    }
}
