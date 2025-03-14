using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.IRepositories;
using CarRentalApplication.POCO;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class CustomerRepository(CarRentalContext carRentalContext) : ICustomerRepository
{
    private readonly DbSet<Customer> _customerContext = carRentalContext.Customers;
    public IEnumerable<Customer> GetAll()
    {
        return _customerContext.ToList();
    }

    public Customer GetById(long id)
    {
        return _customerContext.Find(id);
    }

    public Customer Add(CustomerPoco customerPoco)
    {
        var customer = new Customer();
        customer.Name = customerPoco.Name;
        _customerContext.Add(customer);
        carRentalContext.SaveChanges();
        return customer;
    }

    public int Delete(Customer customer)
    {
        _customerContext.Remove(customer);
        return carRentalContext.SaveChanges();
    }

    public int Update(Customer customer, CustomerPoco customerPoco)
    {
        customer.Name = customerPoco.Name;
        return carRentalContext.SaveChanges();
    }
}
