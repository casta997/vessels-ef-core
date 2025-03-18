using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
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
        public IActionResult RentCar([FromBody] RentalRequest request)
        {
            _rentalService.RentCar(request);
            return Ok();
        }

        [HttpPost("return")]
        public IActionResult ReturnCar([FromBody] ReturnRequest request)
        {
            _rentalService.ReturnCar(request);
            return Ok();
        }
    }
}
