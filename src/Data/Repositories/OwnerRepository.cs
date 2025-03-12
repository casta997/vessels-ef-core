using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class OwnerRepository(MaritimeContext maritimeContext) : IOwnerRepository
{
    public int CreateOwner(Owner owner)
    {
        var resultOperation = -1;
        try
        {
            using var transaction = maritimeContext.Database.BeginTransaction();
            maritimeContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [envDev].[dbo].[Owners] On");
            maritimeContext.Owners.Add(owner);
            resultOperation = maritimeContext.SaveChanges();
            maritimeContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [envDev].[dbo].[Owners] Off");
            transaction.Commit();
            return resultOperation;
        }
        catch { return resultOperation; }
    }

    public List<Owner> ReadOwners() => maritimeContext.Owners.ToList();

    public bool CheckIfIdExist(int id) => maritimeContext.Owners.Any(x => x.Id == id);

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
