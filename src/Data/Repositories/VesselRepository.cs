using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class VesselRepository(MaritimeContext maritimeContext) : IVesselRepository
{
    public Task<List<Vessel>> GetAllAsync()
    {
        return maritimeContext.Vessels.ToListAsync();
    }
}
