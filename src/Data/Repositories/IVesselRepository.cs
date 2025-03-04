using Data.Entities;

namespace Data.Repositories;

public interface IVesselRepository
{
    List<Vessel> ReadVessels();
    void CreateVessel(Vessel v);
    bool CheckIfIdExist(int id);
    int UpdateImoNumber(int id, string imoNumber);
    int DeleteVessel(int id);
    Vessel FindVesselById(int id);
}
