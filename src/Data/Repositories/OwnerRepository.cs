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
}
