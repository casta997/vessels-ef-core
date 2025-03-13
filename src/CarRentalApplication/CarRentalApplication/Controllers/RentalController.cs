using CarRentalApplication.Entities;
using CarRentalApplication.Request;
using CarRentalApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("rentals")]
    public class RentalController(RentalService rentalService) : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var rentals = rentalService.GetAll();
            return Ok(rentals);
        }

        [HttpGet("{rentalId:long}")]
        public IActionResult GetById(long rentalId)
        {
            var rental = rentalService.GetById(rentalId);
            return Ok(rental);
        }

        [HttpPost("rent car")]
        public IActionResult RentCar([FromBody] RentalRequest request)
        {
            rentalService.RentCar(request.CustomerId, request.LicensePlate, request.RentalDate);
            return Ok();
        }

        [HttpPost("return car")]
        public IActionResult ReturnCar([FromBody] ReturnRequest request)
        {
            rentalService.ReturnCar(request.LicensePlate, request.ReturnDate);
            return Ok();
        }

        [HttpPut("{id}/{rentalDate}/{customerId}/{carId}")]
        public IActionResult UpdateObj(long id, long carId, long customerId, DateTime rentalDate, DateTime? returnDate)
        {
            rentalService.UpdateObj(id, carId, customerId, rentalDate, returnDate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteObj(long id)
        {
            rentalService.DeleteObj(id);
            return Ok();
        }

        /*
        [HttpPost("{customerId}/{carId}")]
        public IActionResult RentalCar(long carId, long customerId)
        {
            rentalService.RentCar(carId, customerId);
            return Ok();
        }
        */
    }
}
