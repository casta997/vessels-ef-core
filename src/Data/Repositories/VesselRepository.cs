using Data.Entities;

namespace Data.Repositories;

public class VesselRepository(MaritimeContext maritimeContext) : IVesselRepository
{
    public List<Vessel> ReadVessels() => maritimeContext.Vessels.ToList();

    public int CreateVessel(Vessel vessel)
    {
        try
        {
            maritimeContext.Vessels.Add(vessel);
            return maritimeContext.SaveChanges();
        }
        catch { return -1; }

    }

    public bool CheckIfIdExist(int id) => maritimeContext.Vessels.Any(x => x.Id == id);

    public int UpdateImoNumber(int id, string imoNumber)
    {
        try
        {
            var vessel = FindVesselById(id);
            vessel.ImoNumber = imoNumber;
            return maritimeContext.SaveChanges();
        }
        catch { return -1; }

    }

    public int DeleteVessel(int id)
    {
        try
        {
            maritimeContext.Vessels.Remove(FindVesselById(id));
            return maritimeContext.SaveChanges();
        }
        catch { return -1; }
        
    }

    public Vessel FindVesselById(int id) => maritimeContext.Vessels.Find(id);
}
