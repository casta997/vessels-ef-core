using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Car GetById(long id);
        void CreateObj(string plateNumber);
        void UpdateObj(long id, string plateNumber);
        void DeleteObj(long id);
    }
}
