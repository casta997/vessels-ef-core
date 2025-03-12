using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Car GetById(long id);
    }
}
