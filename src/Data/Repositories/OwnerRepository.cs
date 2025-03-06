using Data.Entities;

namespace Data.Repositories;

public class OwnerRepository(MaritimeContext maritimeContext) : IOwnerRepository
{
    public int CreateOwner(Owner owner)
    {
        try
        {
            maritimeContext.Owners.Add(owner);
            return maritimeContext.SaveChanges();
        }
        catch { return -1; }
    }

    public List<Owner> ReadOwners() => maritimeContext.Owners.ToList();

    public bool CheckIfIdExist(int id) => maritimeContext.Owners.ToList().Exists(x => x.Id == id);

    public int UpdateAllValues(int idOwner, string firstName, bool canChangeFirstName, string lastName, bool canChangeLastName, List<int> idVesselsVerified)
    {
        try
        {
            Owner owner = FindOwnerById(idOwner);
            if (canChangeFirstName)
                owner.FirstName = firstName;

            if (canChangeLastName)
                owner.LastName = lastName;

            if(idVesselsVerified.Count > 0)
            {
                foreach (var v in idVesselsVerified)
                {
                    var vessel = maritimeContext.Vessels.FirstOrDefault(x => x.Id == v);
                    owner.Vessels.Add(vessel);
                }
            }

            return maritimeContext.SaveChanges();
        }
        catch { return -1; }
    }

    public Owner FindOwnerById(int id) => maritimeContext.Owners.Find(id);

    public int DeleteOwner(int id)
    {
        try
        {
            maritimeContext.Owners.Remove(FindOwnerById(id));
            return maritimeContext.SaveChanges();
        }
        catch { return -1; }
    }

    public int AddVessel(int idOwner, int idVessel)
    {
        try
        {
            Owner owner = FindOwnerById(idOwner);
            Vessel vessel = maritimeContext.Vessels.Find(idVessel);

            owner.Vessels.Add(vessel);

            return maritimeContext.SaveChanges();
        }
        catch { return -1; }

    }
}
