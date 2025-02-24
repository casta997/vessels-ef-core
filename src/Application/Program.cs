//using var db = new ManageVesselContext();
//db.Database.MigrateAsync().Wait();

using Application.ManageProgram;

var manageProgram = new OperationsCentralBase();

var isProgramOn = true;

while (isProgramOn)
{
    Console.WriteLine(@"
---------------------Managing Vessels---------------------
Select 1 operation:
CV.- Create a new vessel.
CO.- Create a new owner.
RV.- Display the list of vessels.
RO.- Display the list of owners.
UV.- Update the details of an existing vessel.
UO.- Update the details of an existing owner.
DV.- Delete a vessel.
DO.- Delete an owner.
A.- Assign a vessel to an owner.
");

    string inputTypeOperation = Console.ReadLine();
    Console.Clear();

    switch (inputTypeOperation)
    {
        case "CV":
            manageProgram.AddVessel();
            break;
        case "CO":
            manageProgram.AddOwner();
            break;
        case "RV":
            manageProgram.ShowVessels();
            break;
        case "RO":
            manageProgram.ShowOwners();
            break;
        case "UV":
            manageProgram.UpdateVessel();
            break;
        case "UO":
            manageProgram.UpdateOwner();
            break;
        case "DV":
            manageProgram.DeleteVessel();
            break;
        case "DO":
            manageProgram.DeleteOwner();
            break;
        case "A":
            manageProgram.AssignVesselToOwner();
            break;
        default:
            isProgramOn = false;
            Console.WriteLine("Option not available!!\ntry again...");
            break;
    }
}

