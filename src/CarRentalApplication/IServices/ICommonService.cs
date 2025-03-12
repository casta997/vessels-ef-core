namespace CarRentalApplication.IServices;

public interface ICommonService<T>
{
    IEnumerable<T> GetAll();

    T GetById(long id);
}
