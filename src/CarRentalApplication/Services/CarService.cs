using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.IServices;

namespace CarRentalApplication.Services;

public class CarService(CarRentalContext carRentalContext) : ICarService
{
    public IEnumerable<Car> GetAll()
    {
        return carRentalContext.Cars.ToList();
    }

    public Car GetById(long id)
    {
        throw new NotImplementedException();
    }
}
