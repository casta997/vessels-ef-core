using CarRentalApplication.Dto;
using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;
using CarRentalApplication.Interfaces.Services;
using CarRentalApplication.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CarRentalApplication.Services;

public class CustomerService(IRepositoryFactory repositoryFactory) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = repositoryFactory.GetService<ICustomerRepository>();
    public IEnumerable<IModel> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public Customer? GetById(long id)
    {
        return (Customer)_customerRepository.GetById(id);
    }

    public Customer? Add(CustomerModel customer)
    {
        try
        {
            if (String.IsNullOrEmpty(customer.Name.Trim()))
            {
                return null;
            }
            customer.Name = customer.Name.Trim();

            if (_customerRepository.Add(customer) > 0)
            {
                return GetByName(customer.Name);
            }

            return null;
        }
        catch { return null; }
    }

    public Customer? DeleteById(long id)
    {
        Customer car = GetById(id);
        if (car is not null)
        {
            _customerRepository.Delete(car);
        }
        return car;
    }

    public Customer? Update(long customerId, CustomerModel customerPoco)
    {
        Customer customer = GetById(customerId);
        if (customer is not null)
        {
            var namePoco = customerPoco.Name.Trim();
            if (namePoco.Length > 0 && namePoco != customer.Name)
            {
                _customerRepository.Update(customer, customerPoco);
            }
        }
        return customer;
    }

    public Customer? GetByName(string name)
    {

        return (Customer)_customerRepository.GetByName(name);
    }
}
