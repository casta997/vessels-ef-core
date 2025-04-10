using CarRentalApplication.Context;
using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class CustomerRepository : ContextBase, ICustomerRepository
{
    private readonly CarRentalContext _context;
    private readonly DbSet<Customer> _customerDb;

    public CustomerRepository(CarRentalContext carRentalContext) : base(carRentalContext)
    {
        _context = _carRentalContext;
        _customerDb = _carRentalContext.Customers;
    }

    public IEnumerable<IModel> GetAll()
    {
        return _customerDb.ToList();
    }

    public IModel? GetById(long id)
    {
        return _customerDb.Find(id);
    }

    public IModel? Add(CustomerModel customerModel)
    {
        var customer = new Customer
        {
            Name = customerModel.Name
        };
        _customerDb.Add(customer);

        return _context.SaveChanges() <= 0 ? null : customer;
    }

    public IModel? Delete(Customer customer)
    {
        _customerDb.Remove(customer);
        return _context.SaveChanges() <= 0 ? null : customer;
    }

    public IModel? Update(Customer customer, CustomerModel customerModel)
    {
        customer.Name = customerModel.Name;
        return _context.SaveChanges() <= 0 ? null : customer;
    }
}
