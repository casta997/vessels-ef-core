using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface ICustomerRepository : ICommonRepository
{
    IModel Add(CustomerModel customer);
    IModel Delete(Customer customer);
    IModel Update(Customer customer, CustomerModel customerModel);
}
