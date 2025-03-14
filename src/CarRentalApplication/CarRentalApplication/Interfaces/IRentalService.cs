using CarRentalApplication.Entities;
using CarRentalApplication.Request;

namespace CarRentalApplication.Interfaces
{
    public interface IRentalService
    {
        List<Rental> GetAll();
        Rental GetById(long id);
        //void RentCar(Car car, Customer customer);
        void RentCar(RentalRequest rentalRequest);
        void ReturnCar(ReturnRequest returnRequest);
        void Update(UpdateRentalRequest updateRentalRequest);
        void Delete(long id);
    }
}
