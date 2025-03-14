using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(long id);
        void Create(string name);
        void Update(long id, string name);
        void Delete(long id);
    }
}
