using Data.Entities;

namespace Data.Repositories;

public interface IOwnerRepository
{
    int CreateOwner(Owner owner);
}
