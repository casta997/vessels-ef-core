using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController(CarRentalContext carRentalContext) : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{carId:long}")]
        public IActionResult GetById(long carId)
        {
            return Ok();
        }
    }
}
