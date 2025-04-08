using CarRentalApplication.Dto;
using CarRentalApplication.Dto.Request;
using CarRentalApplication.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("rentals")]
    public class RentalController(IRentalService rentalService) : Controller
    {
        private readonly IRentalService _rentalService = rentalService;
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_rentalService.GetAll());
        }

        [HttpGet("{rentalId:long}")]
        public IActionResult GetById(long rentalId)
        {
            return Ok(_rentalService.GetById(rentalId));
        }


        [HttpPost("rent")]
        public IActionResult RentCar([FromBody] RentalCarModel request)
        {
            _rentalService.RentCar(request);
            return Ok();
        }

        [HttpPost("return")]
        public IActionResult ReturnCar([FromBody] ReturnCarRentedModel request)
        {
            _rentalService.ReturnCar(request);
            return Ok();
        }
    }
}
