using Data.Entities;

namespace Data.Repositories;

public class VesselRepository(MaritimeContext maritimeContext): IVesselRepository
{
    public List<Vessel> ReadVessels()
    {
        return maritimeContext.Vessels.ToList();
    }

    public void CreateVessel(Vessel vessel)
    {
        maritimeContext.Vessels.Add(vessel);
        maritimeContext.SaveChanges();
    }
}
