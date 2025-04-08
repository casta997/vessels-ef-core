using CarRentalApplication.Context;
namespace CarRentalApplication.Repositories;

public class ContextBase(CarRentalContext carRentalContext)
{
    protected readonly CarRentalContext _carRentalContext = carRentalContext;
}