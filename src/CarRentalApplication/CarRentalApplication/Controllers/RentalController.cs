using CarRentalApplication.Interfaces;
using CarRentalApplication.Request;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [ApiController]
    [Route("rentals")]
    public class RentalController(IRentalService rentalService) : Controller
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
            rentalService.RentCar(request);
            return Ok();
        }

        [HttpPost("return car")]
        public IActionResult ReturnCar([FromBody] ReturnRequest request)
        {
            rentalService.ReturnCar(request);
            return Ok();
        }

        [HttpPut("update car")]
        public IActionResult Update([FromBody] UpdateRentalRequest request)
        {
            rentalService.Update(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            rentalService.Delete(id);
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
