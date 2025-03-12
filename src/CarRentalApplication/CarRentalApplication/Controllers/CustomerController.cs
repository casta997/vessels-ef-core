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
    }
}
