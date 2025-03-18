using CarRentalApplication.Dto;
using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface ICustomerRepository : ICommonRepository
{
    //IEnumerable<Customer> GetAll();
    Customer GetById(long id);
    Customer Add(CustomerPoco customer);
    int Delete(Customer customer);
    int Update(Customer customer, CustomerPoco customerPoco);
}
