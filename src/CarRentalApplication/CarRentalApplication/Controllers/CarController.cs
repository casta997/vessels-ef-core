using CarRentalApplication.Interfaces;
using CarRentalApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController(CarService carService) : Controller
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

        [HttpPost("{plateNumber}")]
        public IActionResult CreateObj(string plateNumber)
        {
            carService.CreateObj(plateNumber);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteObj(int id)
        {
            carService.DeleteObj(id);
            return Ok();
        }
    }
}
