using CarRentalApplication.IServices;
using CarRentalApplication.POCO;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController(ICarService carService) : Controller
    {
        private readonly ICarService _carService = carService;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_carService.GetAll());
        }

        [HttpGet("{carId:long}")]
        public IActionResult GetById(long carId)
        {
            return Ok(_carService.GetById(carId));
        }

        [HttpPost]
        public IActionResult Add([FromBody] CarPoco car)
        {
            return Ok(_carService.Add(car));
        }

        [HttpDelete("{carId:long}")]
        public IActionResult DeleteById(long carId)
        {
            return Ok(_carService.DeleteById(carId));
        }
    }
}
