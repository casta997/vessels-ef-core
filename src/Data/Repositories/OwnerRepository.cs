using Data.Entities;

namespace Data.Repositories;

public class OwnerRepository(MaritimeContext maritimeContext): IOwnerRepository
{
    public int CreateOwner(Owner owner)
    {
        try 
        {
            maritimeContext.Owners.Add(owner);
            return maritimeContext.SaveChanges();
        }
        catch 
        {
            return -1;
        }
    }

    public List<Owner> ReadOwners() => maritimeContext.Owners.ToList();

    public bool CheckIfIdExist(int id) => maritimeContext.Owners.ToList().Exists(x => x.Id == id);

    public int UpdateAllValues(int idOwner, string firstName, bool canChangeFirstName, string lastName, bool canChangeLastName)
    {
        Owner owner = FindOwnerById(idOwner);
        if (canChangeFirstName)
            owner.FirstName = firstName;

        if (canChangeLastName)
            owner.LastName = lastName;

        return maritimeContext.SaveChanges();
    }

    public Owner FindOwnerById(int id) => maritimeContext.Owners.Find(id);
}
