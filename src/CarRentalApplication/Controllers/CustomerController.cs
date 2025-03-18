using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Services;
using CarRentalApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController(ICustomerService customerService) : Controller
    {
        private readonly ICustomerService _customerService = customerService;
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll<Customer>());
        }

        [HttpGet("{customerId:long}")]
        public IActionResult GetById(long customerId)
        {
            return Ok(_customerService.GetById(customerId));
        }

        [HttpPost]
        public IActionResult Add([FromBody] CustomerPoco customer)
        {
            return Ok(_customerService.Add(customer));
        }

        [HttpDelete("{customerId:long}")]
        public IActionResult DeleteById(long customerId)
        {
            return Ok(_customerService.DeleteById(customerId));
        }

        [HttpPut("{customerId:long}")]
        public IActionResult Update(long customerId, [FromBody] CustomerPoco customer)
        {
            return Ok(_customerService.Update(customerId, customer));
        }
    }
}
