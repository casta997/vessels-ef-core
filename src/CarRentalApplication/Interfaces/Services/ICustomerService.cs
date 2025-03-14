using CarRentalApplication.Dto;
using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces.Services;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer GetById(long id);
    Customer Add(CustomerPoco customer);
    Customer DeleteById(long id);
    Customer Update(long customerId, CustomerPoco customerPoco);
}
