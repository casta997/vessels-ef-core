using CarRentalApplication.Interfaces;
using CarRentalApplication.Request;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController(ICustomerService customerService) : Controller
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
        public IActionResult Create([FromBody] CustomerRequest request)
        {
            customerService.Create(request.Name);
            return Ok();
        }

        [HttpPut("{id}/{name}")]
        public IActionResult Update(long id, string name)
        {
            customerService.Update(id, name);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            customerService.Delete(id);
            return Ok();
        }
    }
}
