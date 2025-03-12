namespace CarRentalApplication.IServices;

public interface IFactoryService
{
    T GetService<T>();
}
