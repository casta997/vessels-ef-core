using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.RepositoriesInterfaces;
using CarRentalApplication.Services;

namespace CarRentalApplication.Repositories
{
    public class CarRepository(CarRentalContext carContext) :  ICarRepository
    {

        public List<Car> GetAll()
        {
            var cars = carContext.Cars.ToList();
            return cars;
        }
    }
}
