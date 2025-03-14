using CarRentalApplication.Context;

namespace CarRentalApplication.Services
{
    public class ServiceBase
    {
        public readonly CarRentalContext carContext;

        public ServiceBase(CarRentalContext carContext)
        {
            this.carContext = carContext;
        }
    }
}