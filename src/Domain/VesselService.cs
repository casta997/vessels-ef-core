using Data.Entities;
using Data.Repositories;

namespace Domain;

public class VesselService(IVesselRepository vesselRepository) : IRecordManagerService<VesselService>
{
    private readonly IVesselRepository _vesselRepository = vesselRepository;

    private string InsertImoNumber()
    {
        var imoNumber = "";
        var existImoNumber = false;
        while (!existImoNumber)
        {
            Console.Clear();
            Console.WriteLine("Insert IMO Number of the vessel:");
            string msgConsole = Console.ReadLine() ?? String.Empty;

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

    public void ShowAll()
    {
        var vessels = _vesselRepository.ReadVessels();

        if (vessels.Count > 0)
        {
            Console.WriteLine("*****Vessel Information*****");
            Console.WriteLine($"\n Id \t| ImoNumber \t| OwnerId");
            foreach (var ve in vessels)
            {
                Console.WriteLine(ve);
            }
        }
        else
            Console.WriteLine("There are no Vessels!");
    }

    public void Add()
    {
        var imoNumber = InsertImoNumber();

        var vessel = new Vessel()
        {
            ImoNumber = imoNumber
        };

        Console.WriteLine(
            (_vesselRepository.CreateVessel(vessel) > 0)
            ? "Vessel modified successfully."
            : "ok"
            
        );
    }

    public void ModifyValues()
    {
        ShowAll();
        Console.WriteLine("\nInsert id of vessel to modify:");
        string inputConsole = Console.ReadLine() ?? string.Empty; ;
        bool idIsParsed = int.TryParse(inputConsole, out int idVessel);

        if (idIsParsed && idVessel > 0)
        {
            if (_vesselRepository.CheckIfIdExist(idVessel))
            {
                Console.Clear();
                Console.WriteLine("\nInsert imo number to change:");
                var imoNumber = Console.ReadLine() ?? string.Empty;

                Console.WriteLine((_vesselRepository.UpdateImoNumber(idVessel, imoNumber) > 0) ? "Vessel modified successfully." : "No changes were made to the Vessel.");
            }
            else
                Console.WriteLine("Id inserted doesn't exist");
        }
        else
            Console.WriteLine("Id must be a positive number");
    }

    public void Remove()
    {
        ShowAll();
        Console.WriteLine("\nInsert id of vessel to delete:");
        string inputConsole = Console.ReadLine() ?? string.Empty; ;
        bool idIsParsed = int.TryParse(inputConsole, out int idVessel);

        if (idIsParsed && idVessel > 0)
        {
            Console.WriteLine("Are you sure to delete this vessel? Y / N");
            var answerDeleteVessel = Console.ReadKey();

            Console.WriteLine(
                (answerDeleteVessel.KeyChar == 'Y')
                        ? (
                            (_vesselRepository.CheckIfIdExist(idVessel)) 
                                ? (
                                    (_vesselRepository.DeleteVessel(idVessel) > 0)
                                        ? "Vessel deleted successfully."
                                        : "No changes were made to the Vessel.\nPlease try again, or contact the Admin for assistance."
                                    )
                                : "Id inserted doesn't exist"
                            )
                        : "No changes were made to the Vessel."
            );

        }
        else
            Console.WriteLine("Id must be a positive number");
    }

    public void AssociateManyToThis()
    {
        //Not implemented yet. Can be useful for future tasks
    }
}
