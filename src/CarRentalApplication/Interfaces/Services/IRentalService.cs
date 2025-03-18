using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Services;

public interface IRentalService
{
    //IEnumerable<Rental> GetAll();
    IEnumerable<IModel> GetAll<T>() where T : IModel;
    Rental GetById(long id);
    void RentCar(RentalRequest request);
    void ReturnCar(ReturnRequest request);
    Car GetCarByLicensePlate(string LicensePlate);
    Customer GetCustomerById(long CustomerId);
    Rental GetByLicensePlate(string licensePlate);
}
