using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface ICustomerRepository : ICommonRepository
{
    int Add(CustomerModel customer);
    int Delete(Customer customer);
    int Update(Customer customer, CustomerModel customerModel);
    IModel GetByName(string name);
}
