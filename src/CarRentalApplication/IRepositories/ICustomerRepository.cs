using CarRentalApplication.Entities;
using CarRentalApplication.POCO;

namespace CarRentalApplication.IRepositories;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll();
    Customer GetById(long id);
    Customer Add(CustomerPoco customer);
}
