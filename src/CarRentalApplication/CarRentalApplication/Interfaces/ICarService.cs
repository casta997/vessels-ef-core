using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(long id);
        void Create(string plateNumber);
        void Update(long id, string plateNumber);
        void Delete(long id);
    }
}
