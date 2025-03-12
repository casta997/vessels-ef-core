using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{customerId:long}")]
        public IActionResult GetById(long customerId)
        {
            return Ok();
        }
    }
}
