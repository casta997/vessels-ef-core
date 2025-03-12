using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;

namespace CarRentalApplication.Services
{
    public class CustomerService(CarRentalContext carContext) : ICustomerService
    {
        public IEnumerable<Customer> GetAll()
        {
            var customers = carContext.Customers;
            return customers;
        }

        public Customer GetById(long id)
        {
            var customerWithId = carContext.Customers.FirstOrDefault(x => x.Id == id);
            return customerWithId;
        }
    }
}
