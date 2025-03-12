using CarRentalApplication.Context;
using CarRentalApplication.IServices;

namespace CarRentalApplication.Services;

public class CarService(CarRentalContext carRentalContext) : ICarService<CarService>
{
    public IEnumerable<CarService> GetAll()
    {
        return (IEnumerable<CarService>)carRentalContext.Cars.ToList();
    }

    public CarService GetById(long id)
    {
        throw new NotImplementedException();
    }
}
