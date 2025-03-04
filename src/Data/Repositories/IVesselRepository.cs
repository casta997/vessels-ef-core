using Data.Entities;

namespace Data.Repositories;

public interface IVesselRepository
{
    List<Vessel> GetVessels();
}
