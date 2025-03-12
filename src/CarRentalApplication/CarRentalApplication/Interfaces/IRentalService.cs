using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces
{
    public interface IRentalService
    {
        IEnumerable<Rental> GetAll();
        Rental GetById(long id);
        void RentCar(Car car, Customer customer);
        void ReturnCar(Car car);
    }
}
