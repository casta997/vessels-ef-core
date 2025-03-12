using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
        void CreateObj(string name);
    }
}
