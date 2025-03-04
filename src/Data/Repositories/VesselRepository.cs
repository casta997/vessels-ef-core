using Data.Entities;

namespace Data.Repositories;

public class VesselRepository(MaritimeContext maritimeContext): IVesselRepository
{
    public List<Vessel> ReadVessels() => maritimeContext.Vessels.ToList();

    public void CreateVessel(Vessel vessel)
    {
        maritimeContext.Vessels.Add(vessel);
        maritimeContext.SaveChanges();
    }

    public bool CheckIfIdExist(int id) => maritimeContext.Vessels.ToList().Exists(x => x.Id == id);

    public int UpdateImoNumber(int id, string imoNumber) 
    {
        var vessel = FindVesselById(id);
        vessel.ImoNumber = imoNumber;
        return maritimeContext.SaveChanges();
    }

    public int DeleteVessel(int id)
    {
        maritimeContext.Vessels.Remove(FindVesselById(id));
        return maritimeContext.SaveChanges();
    }

    public Vessel FindVesselById(int id) => maritimeContext.Vessels.Find(id);
}
