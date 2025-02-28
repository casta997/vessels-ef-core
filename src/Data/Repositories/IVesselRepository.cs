using Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repositories;

public interface IVesselRepository
{
    Task<List<Vessel>> GetAllAsync();

    Task<EntityEntry<Vessel>> AddSingleRecordAsync(Vessel vessel);
}