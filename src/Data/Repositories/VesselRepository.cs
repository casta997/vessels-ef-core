using Data.Entities;

namespace Data.Repositories;

public class VesselRepository(MaritimeContext maritimeContext)//: IVesselRepository
{
    public List<Vessel> GetVessels()
    {
        return maritimeContext.Vessels.ToList();
    }

}
