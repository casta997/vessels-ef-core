using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;

namespace CarRentalApplication.Services
{
    public class CarService(CarRentalContext carContext) : ICarService
    {
        public IEnumerable<Car> GetAll()
        {
            var allCars = carContext.Cars;
            return allCars;
        }

        public Car GetById(long id)
        {
            var carWithId = carContext.Cars.FirstOrDefault(c => c.Id == id);
            return carWithId;
        }
    }
}
