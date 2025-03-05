using Data.Entities;
using Data.Repositories;

namespace Domain;

public class OwnerService : IRecordManagerService<OwnerService>
{
    private readonly IOwnerRepository _ownerRepository;
    public OwnerService(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    private string insertFirstName()
    {
        Console.WriteLine("Insert first name:");
        var firstName = Console.ReadLine();

        return firstName;
    }

    private string insertLastName()
    {
        var lastName = "";
        var existLastName = false;
        while (!existLastName)
        {
            Console.Clear();
            Console.WriteLine("Insert last name of the owner:");
            var msgConsole = Console.ReadLine();

            if (msgConsole.Trim().Length != 0)
            {
                lastName = msgConsole;
                existLastName = true;
            }
            else
            {
                Console.WriteLine("Last name is a required field!");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
            }
        }

        return lastName;
    }

    private string ChangeFirstNameOwner()
    {
        Console.Clear();
        Console.WriteLine("Insert new first name:");
        return Console.ReadLine();
    }

    private string ChangeLastNameOwner()
    {
        var lastName = "";
        var existLastName = false;
        //Try for tentatives, maybe with 'for' iteration of 5 opportunities
        while (!existLastName)
        {
            Console.Clear();
            Console.WriteLine("Insert new last name:");
            var inputConsole = Console.ReadLine() ?? string.Empty;

            if (inputConsole.Trim().Length != 0)
            {
                lastName = inputConsole;
                existLastName = true;
            }
            else
            {
                Console.WriteLine("Last name is a required field!");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
            }
        }

        return lastName;
    }

    /*
    private List<Vessel> insertVessels()
    {
        var newInsert = true;
        var list = new List<Vessel>();

        while (newInsert)
        {
            Console.Clear();
            Console.WriteLine("Do you want insert a vessel? Y / n");
            var inputInsertVessel = Console.ReadKey();

            if (inputInsertVessel.KeyChar == 'Y')
            {
                var vessel = createVessel();
                list.Add(vessel);
            }
            else
            {
                newInsert = false;
            }
        }

        return list;
    }
    */

    public void Add()
    {
        var firstName = insertFirstName();
        var lastName = insertLastName();
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

                // update value vessel of owner (is possible to do the following operations:
                //  add Vessel
                //  delete Vessel
                // )

                Console.WriteLine((_ownerRepository
                    .UpdateAllValues(idOwner, firstName, canChangeFirstName, lastName, canChangeLastName) > 0)
                        ? "Owner modified successfully." : "No changes were made to the Owner.");
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
            foreach (var ow in owners)
            {
                Console.WriteLine(ow);
            }
        }
        else
            Console.WriteLine("There are no Owners!");
    }
}
