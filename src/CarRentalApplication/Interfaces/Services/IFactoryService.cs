namespace CarRentalApplication.Interfaces.Services;

public interface IFactoryService
{
    T GetService<T>();
}
