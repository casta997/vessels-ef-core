using Data.Entities;
using Data.Repositories;

namespace Domain;

public class VesselService(IVesselRepository vesselRepository) : IVesselService
{
    private string InsertImoNumber()
    {
        var imoNumber = "";
        var existImoNumber = false;
        while (!existImoNumber)
        {
            Console.Clear();
            Console.WriteLine("Insert IMO Number of the vessel:");
            string msgConsole = Console.ReadLine();

            if (msgConsole.Trim().Length != 0)
            {
                imoNumber = msgConsole;
                existImoNumber = true;
            }
            else
            {
                BreakConcludeOperation("IMO Number is a required field!");
            }
        }

        return imoNumber;
    }

    internal void BreakConcludeOperation(string errorMessage)
    {
        Console.WriteLine($"{errorMessage}\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    /*
    private int changeValuesForVessel()
    {
        ShowVessels();
        var idVessel = -1;
        Console.WriteLine("\nInsert id of vessel to update:");
        string inputIdVessel = Console.ReadLine();

        bool success = int.TryParse(inputIdVessel, out idVessel);

        if (success)
        {
            var vessel = _dbMaritimeContext.Vessels
                    .Find(idVessel);

            try
            {
                if (!vessel.Equals(null))
                {
                    Console.Clear();
                    Console.WriteLine("\nInsert imo number to change:");
                    var imoNumber = Console.ReadLine();
                    vessel.ImoNumber = imoNumber;
                }
            }
            catch (Exception)
            {
                idVessel = -1;
                Console.Clear();
                Console.WriteLine("Vessel not found!");
                throw;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Id has to be a number of type int!");
        }

        return idVessel;
    }

    private int checkIfVesselCanBeDeleted()
    {
        var idVesselFound = -1;
        ShowVessels();
        Console.WriteLine("\nInsert id of vessel to delete:");
        string inputIdVessel = Console.ReadLine();

        bool success = int.TryParse(inputIdVessel, out int idVessel);

        if (success)
        {
            var vessel = _dbMaritimeContext.Vessels
            .Find(idVessel);

            try
            {
                if (!vessel.Equals(null))
                {
                    Console.WriteLine("Are you sure to delete this vessel? Y / n");
                    var answerDeleteVessel = Console.ReadKey();

                    if (answerDeleteVessel.KeyChar == 'Y')
                    {
                        idVesselFound = idVessel;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Vessel not found!");
                throw;
            }

            Console.Clear();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Id has to be a number of type int!");
        }

        return idVesselFound;
    }

    private int checkVesselById()
    {
        var inputIdVessel = Console.ReadLine();

        if (int.TryParse(inputIdVessel, out int idVessel))
        {
            var vessel = _dbMaritimeContext.Vessels
                .Find(idVessel);

            if (vessel.Equals(null))
                idVessel = -1;
        }
        return idVessel;
    }

    private int checkOwnerById()
    {
        var inputIdOwner = Console.ReadLine();

        if (int.TryParse(inputIdOwner, out int idOwner))
        {
            var owner = _dbMaritimeContext.Owners
                .Find(idOwner);

            if (owner.Equals(null))
                idOwner = -1;
        }
        return idOwner;
    }
    */
    public void ShowAll()
    {
        var vessels = vesselRepository.ReadVessels();

        foreach (var ve in vessels)
        {
            Console.WriteLine(ve);
        }
    }

    public void AddVessel()
    {
        var imoNumber = InsertImoNumber();

        var vessel = new Vessel()
        {
            ImoNumber = imoNumber
        };

        vesselRepository.CreateVessel(vessel);
    }
}
