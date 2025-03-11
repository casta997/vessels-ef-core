using Data.Entities;
using Data.Repositories;
using Microsoft.Extensions.Logging;

namespace Domain;

public class OwnerService(IOwnerRepository ownerRepository, IVesselRepository vesselRepository, ILogger<OwnerService> loggerOwner) : IRecordManagerService<OwnerService>
{
    private readonly IOwnerRepository _ownerRepository = ownerRepository;
    private readonly IVesselRepository _vesselRepository = vesselRepository;
    private readonly ILogger<OwnerService> _loggerOwner = loggerOwner;

    private string InsertFirstName()
    {
        //Console.Clear();
        _loggerOwner.LogInformation("Insert first name:");
        var firstName = Console.ReadLine();

        return firstName;
    }

    private string InsertLastName()
    {
        var lastName = "";
        var existLastName = false;
        while (!existLastName)
        {
            _loggerOwner.LogInformation("Insert last name of the owner:");
            var msgConsole = Console.ReadLine() ?? String.Empty;

            if (msgConsole.Trim().Length != 0)
            {
                lastName = msgConsole;
                existLastName = true;
            }
            else
            {
                _loggerOwner.LogInformation("Last name is a required field!\nPress any key to continue... \n");
                Console.ReadKey();
            }
        }

        return lastName;
    }

    /*
    private void StopAndClearAndPrintMessageDynamic(int levelClear, string msg, int logLevel)
    {
        if (levelClear == 0)
        {
            PrintLog(msg, logLevel);
        }
        if (levelClear == 1)
        {
            Console.Clear();
            PrintLog(msg, logLevel);
        }

        if (levelClear == 3)
        {
            PrintLog(msg, logLevel);
            Console.ReadKey();
            Console.Clear();
        }
    }
    */

    /*
    private void PrintLog(string msg, int logLevel)
    {
        switch (logLevel)
        {
            case 0:
                _loggerOwner.LogTrace(msg);
                break;
            case 1:
                _loggerOwner.LogDebug(msg);
                break;
            case 2:
                _loggerOwner.LogInformation(msg);
                break;
            case 3:
                _loggerOwner.LogWarning(msg);
                break;
            case 4:
                _loggerOwner.LogError(msg);
                break;
            case 5:
                _loggerOwner.LogCritical(msg);
                break;
            case 6:
                _loggerOwner.Log(LogLevel.None, msg);
                break;
            default:
                _loggerOwner.LogError("Value log level not recognized.");
                break;
        }
    }
    */

    private string ChangeFirstNameOwner()
    {
        //Console.Clear();
        _loggerOwner.LogInformation("Insert new first name:");
        return Console.ReadLine()?? String.Empty;
    }

    private string ChangeLastNameOwner()
    {
        var lastName = "";
        var existLastName = false;
        //Try for tentatives, maybe with 'for' iteration of 5 opportunities
        while (!existLastName)
        {
            //Console.Clear();
            _loggerOwner.LogInformation("Insert new last name:");
            var inputConsole = Console.ReadLine() ?? string.Empty;

            if (inputConsole.Trim().Length != 0)
            {
                lastName = inputConsole;
                existLastName = true;
            }
            else
            {
                _loggerOwner.LogInformation("Last name is a required field!\nPress any key to continue... \n");
                Console.ReadKey();
            }
        }

        return lastName;
    }

    public void Add()
    {
        var firstName = InsertFirstName();
        var lastName = InsertLastName();
        //var vessels = insertVessels();

        var owner = new Owner()
        {
            FirstName = firstName,
            LastName = lastName
        };

        /*
        foreach (var item in vessels)
        {
            owner.Vessels.Add(item);
        }
        */

        var numberEntitiesSaved = _ownerRepository.CreateOwner(owner);

        Console.WriteLine(
            (numberEntitiesSaved > -1)
                ? (numberEntitiesSaved > 0)
                    ? "\nOwner added correctly!"
                    : "\nNo Owner was saved. Save action issue"
                : "\nError with adding of owner"
        );
    }

    public void ModifyValues()
    {
        ShowAll();
        Console.WriteLine("\nInsert id of owner to modify:");
        string inputConsole = Console.ReadLine() ?? string.Empty; ;
        bool idIsParsed = int.TryParse(inputConsole, out int idOwner);

        if (idIsParsed && idOwner > 0)
        {
            if (_ownerRepository.CheckIfIdExist(idOwner))
            {
                string firstName = "", lastName = "";
                bool canChangeFirstName = false, canChangeLastName = false;
                Console.Clear();
                Console.WriteLine("\nDo you want to modify first name? Y / N");

                var answerFirstName = Console.ReadKey();

                if (answerFirstName.KeyChar == 'Y')
                {
                    Console.Clear();
                    firstName = ChangeFirstNameOwner();
                    canChangeFirstName = true;
                }

                Console.WriteLine("\nDo you want to modify last name? Y / N");
                var answerLastName = Console.ReadKey();

                if (answerLastName.KeyChar == 'Y')
                {
                    Console.Clear();
                    lastName = ChangeLastNameOwner();
                    canChangeLastName = true;
                }

                var listIdVesselToAddToOwner = QuestionVesselToModify();

                // update value vessel of owner (is possible to do the following operations:
                //  assign Vessel
                //  unassign Vessel
                // )

                Console.WriteLine((_ownerRepository
                    .UpdateAllValues(idOwner, firstName, canChangeFirstName, lastName, canChangeLastName, listIdVesselToAddToOwner) > 0)
                        ? "Owner modified successfully." : "No changes were made to the Owner.");
            }
            else
                Console.WriteLine("Id inserted doesn't exist");
        }
        else
            Console.WriteLine("Id must be a positive number");
    }

    public List<int> QuestionVesselToModify()
    {
        List<int> listIdVesselVerifiedToAssign = [];
        bool continueToModify = true;
        do
        {
            Console.WriteLine("\nDo you want to modify the vessel list? Y / N");
            var answerModifyVesselList = Console.ReadKey();

            if (answerModifyVesselList.KeyChar == 'Y')
            {
                Console.Clear();
                Console.WriteLine("\nDo you want to assign a vessel or revoke? A / R");
                var answerAssignOrRevoke = Console.ReadKey();

                if (answerAssignOrRevoke.KeyChar == 'A')
                {
                    Console.Clear();
                    Console.Write("\nEnter vessel id: ");
                    string? idVesselToAssign = Console.ReadLine();
                    bool idVesselIsConverted = int.TryParse(idVesselToAssign, out int idVesselParsed);
                    if (idVesselIsConverted && idVesselParsed > 0)
                    {
                        if (_vesselRepository.CheckIfIdExist(idVesselParsed))
                        {
                            listIdVesselVerifiedToAssign.Add(idVesselParsed);
                        }
                        else
                            Console.WriteLine("Id inserted doesn't exist");
                    }
                    else
                        Console.WriteLine("Id must be a positive number");
                }

                if (answerAssignOrRevoke.KeyChar == 'R')
                {

                }
            }

            if (answerModifyVesselList.KeyChar == 'N')
            {
                continueToModify = false;
            }
        }
        while (continueToModify);

        return listIdVesselVerifiedToAssign;
    }

    public void Remove()
    {
        ShowAll();
        Console.WriteLine("\nInsert id of owner to delete:");
        string inputConsole = Console.ReadLine() ?? string.Empty; ;
        bool idIsParsed = int.TryParse(inputConsole, out int idOwner);

        if (idIsParsed && idOwner > 0)
        {
            Console.WriteLine("Are you sure to delete this owner? Y / N");
            var answerDeleteOwner = Console.ReadKey();

            Console.WriteLine(
                (answerDeleteOwner.KeyChar == 'Y')
                    ? (
                        (_ownerRepository.CheckIfIdExist(idOwner))
                            ? (
                                (_ownerRepository.DeleteOwner(idOwner) > 0)
                                    ? "Owner deleted successfully."
                                    : "No changes were made to the Owner.\nPlease try again, or contact the Admin for assistance."
                                )
                            : "Id inserted doesn't exist"
                        )
                    : "No changes were made to the Owner."
            );
        }
        else
            Console.WriteLine("Id must be a positive number");
    }

    public void ShowAll()
    {
        var owners = _ownerRepository.ReadOwners();

        if (owners.Count > 0)
        {
            Console.WriteLine("*****Owner Information*****");
            Console.WriteLine($"\n Id \t| First name \t\t| Last name");
            foreach (var ow in owners)
            {
                Console.WriteLine(ow);
            }
        }
        else
            Console.WriteLine("There are no Owners!");
    }

    public void AssociateManyToThis()
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

        Console.WriteLine("Insert id of the Vessel to assign:");

        string inputConsole = Console.ReadLine() ?? string.Empty; ;
        bool idIsParsed = int.TryParse(inputConsole, out int idVessel);

        if (idIsParsed && idVessel > 0)
        {
            Console.Clear();
            Console.WriteLine("Are you sure to assign this vessel? Y / N");
            var confirmationAnswerOwner = Console.ReadKey();

            Console.WriteLine(
                (confirmationAnswerOwner.KeyChar == 'Y')
                    ? (
                        (_vesselRepository.CheckIfIdExist(idVessel))
                            ? AssignVesselToOwner(idVessel)
                            : "Id inserted doesn't exist"
                    )
                    : "No changes were made to the Owner."
            );
        }
        else
            Console.WriteLine("Id must be a positive number");
    }

    private string AssignVesselToOwner(int idVessel)
    {
        Console.Clear();
        ShowAll();
        Console.WriteLine("\nInsert id of the owner:");

        string inputConsole = Console.ReadLine() ?? string.Empty; ;
        bool idIsParsed = int.TryParse(inputConsole, out int idOwner);

        if (idIsParsed && idOwner > 0)
        {
            Console.Clear();
            return (_ownerRepository.CheckIfIdExist(idOwner))
                        ? (
                            (_ownerRepository.AddVessel(idOwner, idVessel) > 0)
                                ? "Vessel assigned correctly!"
                                : "No changes were made to the Owner.\nPlease try again, or contact the Admin for assistance."
                         )
                        : "Id inserted doesn't exist"
                ;
        }
        else
            return "Id must be a positive number";
    }
}
