using CarRentalApplication.IServices;
using CarRentalApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController(IFactoryService factoryService) : Controller
    {
        private readonly ICarService<CarService> _carService = factoryService.GetService<ICarService<CarService>>();

        [HttpGet]
        public IActionResult GetAll()
        {
            var a = _carService.GetAll();
            Console.WriteLine(a.ToList().ToString());
            return Ok();
        }

        [HttpGet("{carId:long}")]
        public IActionResult GetById(long carId)
        {
            return Ok();
        }
    }
}
