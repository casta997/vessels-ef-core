using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces.RepositoriesInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetAll();
    }
}
