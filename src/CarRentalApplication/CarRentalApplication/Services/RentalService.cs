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

        public void UpdateObj(long id, long carId, long customerId, DateTime rentalDate, DateTime? returnDate)
        {
            var findRental = carContext.Rentals.FirstOrDefault(r => r.Id == id);

            if (findRental != null)
            {
                findRental.RentalDate = rentalDate;
                findRental.ReturnDate = returnDate;
                findRental.CarId = carId;
                findRental.CustomerId = customerId;

                var findCar = carContext.Cars.FirstOrDefault(c => c.Id == findRental.CarId);

                if (returnDate == null)
                {
                    findCar.IsRented = true;
                }
                else
                {
                    findCar.IsRented = false;
                }

                carContext.SaveChanges();
            }
        }

        public void DeleteObj(long id)
        {
            var findRent = carContext.Rentals.FirstOrDefault(r => r.Id == id);

            if(findRent != null)
            {
                var findCar = carContext.Cars.FirstOrDefault(c => c.Id == findRent.CarId);

                if(findRent.ReturnDate == null)
                {
                    findCar.IsRented = false;
                }

                carContext.Rentals.Remove(findRent);
                carContext.SaveChanges();
            }
        }
    }
}
