using CarRentalApplication.Interfaces;
using CarRentalApplication.Request;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController(ICarService carService) : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var cars = carService.GetAll();
            return Ok(cars);
        }

        [HttpGet("{carId:long}")]
        public IActionResult GetById(long carId)
        {
            var car = carService.GetById(carId);
            return Ok(car);
        }

        [HttpPost("create car")]
        public IActionResult Create([FromBody] CarRequest request)
        {
            carService.Create(request.LicensePlate);
            return Ok();
        }

        [HttpPut("{id}/{plateNumber}")]
        public IActionResult Update(long id, string plateNumber)
        {
            carService.Update(id, plateNumber);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            carService.Delete(id);
            return Ok();
        }
    }
}
