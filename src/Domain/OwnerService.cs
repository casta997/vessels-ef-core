using Data.Entities;
using Data.Repositories;

namespace Domain;

public class OwnerService: IRecordManagerService<OwnerService>
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
        throw new NotImplementedException();
    }

    public void Remove()
    {
        throw new NotImplementedException();
    }

    public void ShowAll()
    {
        throw new NotImplementedException();
    }
}
