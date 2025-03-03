using Application.DBContext;
using Application.ManageProgram;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = Host.CreateApplicationBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("MaritimeDb")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services
    .AddTransient<OperationsCentralBase>()
    .AddDbContext<ManageVesselContext>(options => options.UseSqlServer(connectionString));



using var host = builder.Build();


var manageProgram = host.Services.GetService<OperationsCentralBase>();

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
    string stateFunction = "";

    switch (inputTypeOperation)
    {
        case "CV":
            stateFunction = manageProgram.AddVessel();
            break;
        case "CO":
            stateFunction = manageProgram.AddOwner();
            break;
        case "RV":
            stateFunction = manageProgram.ShowVessels();
            break;
        case "RO":
            stateFunction = manageProgram.ShowOwners();
            break;
        case "UV":
            stateFunction = manageProgram.UpdateVessel();
            break;
        case "UO":
            stateFunction = manageProgram.UpdateOwner();
            break;
        case "DV":
            stateFunction = manageProgram.DeleteVessel();
            break;
        case "DO":
            stateFunction = manageProgram.DeleteOwner();
            break;
        case "A":
            manageProgram.AssignVesselToOwner();
            break;
        default:
            isProgramOn = false;
            Console.WriteLine("Option not available!!\ntry again...");
            break;
    }

    manageProgram.BreakConcludeOperation(stateFunction);

    if (inputTypeOperation == "CV" || inputTypeOperation == "CO" || inputTypeOperation == "RV" || inputTypeOperation == "RO" || inputTypeOperation == "UV" 
        || inputTypeOperation == "UO" || inputTypeOperation == "DV" || inputTypeOperation == "DO" || inputTypeOperation == "A")
    {
        manageProgram.ShowOwners();
        Console.WriteLine("\n\n");
        manageProgram.ShowVessels();
        manageProgram.BreakConcludeOperation("");
    }

}

