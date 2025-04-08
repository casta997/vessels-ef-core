using CarRentalApplication.Context;
using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class CarRepository : ContextBase, ICarRepository
{
    private readonly CarRentalContext _context;
    private readonly DbSet<Car> _carDb;

    public CarRepository(CarRentalContext carRentalContext) : base(carRentalContext)
    {
        _context = _carRentalContext;
        _carDb = _carRentalContext.Cars;
    }

    public IEnumerable<IModel> GetAll()
    {
        return _carDb.ToList();
    }

    public IModel GetById(long id)
    {
        return _carDb.Find(id);
    }

    public Car GetByLicensePlate(string LicensePlate)
    {
        return _carDb.FirstOrDefault(c => c.LicensePlate.Equals(LicensePlate));
    }

    public int Add(CarModel carModel)
    {
        var car = new Car
        {
            LicensePlate = carModel.LicensePlate,
            IsRented = false
        };
        _carDb.Add(car);
        return _context.SaveChanges();
    }

    public int UpdateIsRented(long carId, bool isRented)
    {
        var carFound = (Car)GetById(carId);
        carFound.IsRented = isRented;
        return _context.SaveChanges();
    }

    public int Delete(Car car)
    {
        _carDb.Remove(car);
        return _context.SaveChanges();
    }
    public int Update(Car car, CarModel carModel)
    {
        car.LicensePlate = carModel.LicensePlate;
        return _context.SaveChanges();
    }
}
