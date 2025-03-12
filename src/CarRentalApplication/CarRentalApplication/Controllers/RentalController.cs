using CarRentalApplication.Entities;
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
    }
}
