using Data.Entities;

namespace Data.Repositories;

public interface IOwnerRepository
{
    Task<List<Owner>> GetAllAsync();
}