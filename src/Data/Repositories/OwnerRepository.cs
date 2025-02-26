using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class OwnerRepository(MaritimeContext maritimeContext) : IOwnerRepository
{
    public Task<List<Owner>> GetAllAsync()
    {
        return maritimeContext.Owners.ToListAsync();
    }
}
