using CarRentalApplication.Entities;
using CarRentalApplication.Request;

namespace CarRentalApplication.Interfaces
{
    public interface IRentalService
    {
        IEnumerable<Rental> GetAll();
        Rental GetById(long id);
        //void RentCar(Car car, Customer customer);
        void RentCar(RentalRequest rentalRequest);
        void ReturnCar(ReturnRequest returnRequest);
        void UpdateObj(long id, long carId, long customerId, DateTime rentalDate, DateTime? returnDate);
        void DeleteObj(long id);
    }
}
