using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repositories;

public class VesselRepository(MaritimeContext maritimeContext) : IVesselRepository
{
    public Task<List<Vessel>> GetAllAsync()
    {
        return maritimeContext.Vessels.ToListAsync();
    }

    public Task<EntityEntry<Vessel>> AddSingleRecordAsync() {

        var vessel = maritimeContext.Vessels.AddAsync(new Vessel() { ImoNumber = "MKO590348" });
        var taskVessel = vessel.AsTask();
        maritimeContext.SaveChanges();

        return taskVessel;
    }
}
