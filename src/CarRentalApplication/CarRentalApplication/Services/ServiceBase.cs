using CarRentalApplication.Context;
using CarRentalApplication.Interfaces.RepositoriesInterfaces;

namespace CarRentalApplication.Services
{
    public class ServiceBase
    {
        protected readonly CarRentalContext carContext;
        protected readonly ICarRepository _carRepository;

        public ServiceBase(CarRentalContext carContext, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            this.carContext = carContext;
        }
    }
}