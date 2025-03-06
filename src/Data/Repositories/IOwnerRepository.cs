using Data.Entities;

namespace Data.Repositories;

public interface IOwnerRepository
{
    int CreateOwner(Owner owner);
    List<Owner> ReadOwners();
    bool CheckIfIdExist(int id);
    int UpdateAllValues(int idOwner, string firstName, bool canChangeFirstName, string lastName, bool canChangeLastName, List<int> idVesselsVerified);
    Owner FindOwnerById(int id);
    int DeleteOwner(int id);
    int AddVessel(int idOwner, int idVessel);
}
