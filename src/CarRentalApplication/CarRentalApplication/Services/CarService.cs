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

        public void CreateObj(string plateNumber)
        {
            Car newCar = new() { IsRented = false, LicensePlate = plateNumber};
            carContext.Cars.Add(newCar);
            carContext.SaveChanges();
        }

        public void UpdateObj(long id, string plateNumber)
        {
            var findCar = carContext.Cars.FirstOrDefault(c => c.Id == id);

            if (findCar != null)
            {
                findCar.LicensePlate = plateNumber;
                carContext.SaveChanges();
            }
        }

        public void DeleteObj(long id)
        {
            var findCar = carContext.Cars.FirstOrDefault(c => c.Id == id);
            
            if (findCar != null)
            {
                carContext.Cars.Remove(findCar);
                carContext.SaveChanges();
            }
        }
    }
}
