using CarRentalApplication.Dto.Request;
using CarRentalApplication.Interfaces.Services;
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
        public IActionResult Add([FromBody] CarModel car)
        {
            return Ok(_carService.Add(car));
        }

        [HttpDelete("{carId:long}")]
        public IActionResult DeleteById(long carId)
        {
            return Ok(_carService.DeleteById(carId));
        }

        [HttpPut("{carId:long}")]
        public IActionResult Update(long carId, [FromBody] CarModel car)
        {
            return Ok(_carService.Update(carId, car));
        }
    }
}
