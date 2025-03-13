using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces
{
    public interface IRentalService
    {
        IEnumerable<Rental> GetAll();
        Rental GetById(long id);
        //void RentCar(Car car, Customer customer);
        void RentCar(long customerId, string licensePlate, DateTime rentalDate);
        void ReturnCar(string licensePlate, DateTime rentalDate);
        void UpdateObj(long id, long carId, long customerId, DateTime rentalDate, DateTime? returnDate);
        void DeleteObj(long id);
    }
}
