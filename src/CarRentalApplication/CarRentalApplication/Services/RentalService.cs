using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CarRentalApplication.Services
{
    public class RentalService(CarRentalContext carContext) : IRentalService
    {
        public IEnumerable<Rental> GetAll()
        {
            var allRentals = carContext.Rentals;
            return allRentals;
        }

        public Rental GetById(long id)
        {
            var rentalWithId = carContext.Rentals.FirstOrDefault(r => r.Id == id);
            return rentalWithId;
        }    

        public void RentCar(Car car, Customer customer)
        {
            var findCar = carContext.Cars.Find(car);
            var findCustomer = carContext.Customers.Find(customer);
            
            if(findCar != null && findCustomer != null) 
            {
                Rental newRental = new() { CustomerId = customer.Id, CarId = car.Id, RentalDate = DateTime.Now };
                findCar.IsRented = true;
                carContext.Rentals.Add(newRental);
                carContext.SaveChanges();
            }
        }

        public void ReturnCar(Car car)
        {
            var findCar = carContext.Cars.Find(car);

            if(findCar != null)
            {
                var findRental = carContext.Rentals.FirstOrDefault(r => r.CarId == car.Id && r.ReturnDate == null);


                if (findRental != null)
                {
                    findRental.ReturnDate = DateTime.Now;
                    findCar.IsRented = false;
                    carContext.SaveChanges();
                }
            }
        }
    }
}
