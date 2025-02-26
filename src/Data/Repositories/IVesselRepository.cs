using Data.Entities;

namespace Data.Repositories;

public interface IVesselRepository
{
    Task<List<Vessel>> GetAllAsync();
}