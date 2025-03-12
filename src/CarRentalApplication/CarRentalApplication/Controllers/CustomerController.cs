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

        [HttpPost("{name}")]
        public IActionResult CreateObj(string name)
        {
            customerService.CreateObj(name);
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
