using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;

namespace CarRentalApplication.Services
{
    public class CustomerService(CarRentalContext carContext) : ICustomerService
    {
        public List<Customer> GetAll()
        {
            List<Customer> customers = carContext.Customers.ToList();
            return customers;
        }

        public Customer GetById(long id)
        {
            var customerWithId = carContext.Customers.FirstOrDefault(x => x.Id == id);
            return customerWithId;
        }

        public void Create(string name)
        {
            Customer newCustomer = new() { Name = name };
            carContext.Customers.Add(newCustomer);
            carContext.SaveChanges();
        }

        public void Update(long id, string name)
        {
            var findCar = carContext.Customers.FirstOrDefault(c => c.Id == id);

            if(findCar != null)
            {
                findCar.Name = name;
                carContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var findCustomer = carContext.Customers.FirstOrDefault(c => c.Id == id);

            if (findCustomer != null)
            {
                var findRental = carContext.Rentals.Where(r => r.CustomerId == id).FirstOrDefault(r => r.ReturnDate == null);

                if (findRental != null)
                {
                    findRental.ReturnDate = DateTime.Now;

                    var findCar = carContext.Cars.FirstOrDefault(c => c.Id == findRental.CarId);

                    findCar.IsRented = false;
                }

                carContext.Customers.Remove(findCustomer);
                carContext.SaveChanges();
            }
        }
    }
}
