using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;

namespace CarRentalApplication.Services
{
    public class CarService(CarRentalContext carContext) : ICarService
    {
        public List<Car> GetAll()
        {
            List<Car> allCars = carContext.Cars.ToList();
            return allCars;
        }

        public Car GetById(long id)
        {
            var carWithId = carContext.Cars.FirstOrDefault(c => c.Id == id);
            return carWithId;
        }

        public void Create(string plateNumber)
        {
            var findPlateNumber = carContext.Cars.FirstOrDefault(c => c.LicensePlate == plateNumber);

            if (findPlateNumber == null)
            {
                Car newCar = new() { IsRented = false, LicensePlate = plateNumber };
                carContext.Cars.Add(newCar);
                carContext.SaveChanges();
            }
        }

        public void Update(long id, string plateNumber)
        {
            var findCar = carContext.Cars.FirstOrDefault(c => c.Id == id);

            if (findCar == null)
            {
                return;
            }

            var findPlateNumber = carContext.Cars.FirstOrDefault(c => c.LicensePlate == plateNumber);

            if (findPlateNumber == null)
            {
                findCar.LicensePlate = plateNumber;
                carContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var findCar = carContext.Cars.FirstOrDefault(c => c.Id == id);
            var findRental = carContext.Rentals.Where(r => r.CarId == id);

            if (findCar == null)
            {
                return;
            }

            findRental.ToList();

            foreach (Rental r in findRental)
            {
                if (r.ReturnDate == null)
                {
                    r.ReturnDate = DateTime.Now;
                }
            }

            carContext.Cars.Remove(findCar);
            carContext.SaveChanges();
        }
    }
}
