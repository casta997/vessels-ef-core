using CarRentalApplication.Dto;
using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;
using CarRentalApplication.Interfaces.Services;

namespace CarRentalApplication.Services;

public class RentalService(IRepositoryFactory repositoryFactory) : IRentalService
{
    private readonly IRentalRepository _rentalRepository = repositoryFactory.GetService<IRentalRepository>();
    private readonly ICarRepository _carRepository = repositoryFactory.GetService<ICarRepository>();
    private readonly ICustomerRepository _customerRepository = repositoryFactory.GetService<ICustomerRepository>();
    public IEnumerable<IModel> GetAll()
    {
        return _rentalRepository.GetAll();
    }

    public Rental GetById(long id)
    {
        return (Rental)_rentalRepository.GetById(id);
    }

    public void RentCar(RentalCarModel request) {
        var car = GetCarByLicensePlate(request.LicensePlate);
        var customer = GetCustomerById(request.CustomerId);

        if (car is not null && customer is not null && !car.IsRented)
        {
            if (_rentalRepository.RentCar(car.Id, customer.Id, request.RentalDate) > 0)
            {
                _carRepository.UpdateIsRented(car.Id, true);
            }
        }
    }
    public void ReturnCar(ReturnCarRentedModel request) {
        var car = GetCarByLicensePlate(request.LicensePlate);

        if (car is not null && car.IsRented)
        {
            Rental rental = GetByLicensePlate(car.LicensePlate);

            if (rental.RentalDate < request.ReturnDate && _rentalRepository.UpdateRental(rental, request.ReturnDate) > 0)
            {
                _carRepository.UpdateIsRented(car.Id, false);
            }
        }

    }

    public Rental? GetByLicensePlate(string licensePlate)
    {
        if (String.IsNullOrEmpty(licensePlate.Trim()))
        {
            return null;
        }

        var car = GetCarByLicensePlate(licensePlate);

        return _rentalRepository.GetByLicensePlate(car.Id);
    }

    
    public Car? GetCarByLicensePlate(string licensePlate) {
        if (String.IsNullOrEmpty(licensePlate.Trim()))
        {
            return null;
        }

        return _carRepository.GetByLicensePlate(licensePlate);
    }
    
    public Customer? GetCustomerById(long customerId) {
        return (Customer)_customerRepository.GetById(customerId);
    }
}
