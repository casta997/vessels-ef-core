using CarRentalApplication.IServices;
using CarRentalApplication.POCO;
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
            return Ok(_customerService.GetAll());
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
    }
}
