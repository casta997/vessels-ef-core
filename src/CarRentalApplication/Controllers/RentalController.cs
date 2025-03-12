using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("rentals")]
    public class RentalController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{rentalId:long}")]
        public IActionResult GetById(long rentalId)
        {
            return Ok();
        }
    }
}
