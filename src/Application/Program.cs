using Application.ManageProgram;
using Domain;
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
    .AddTransient<VesselService>()
    .AddTransient<OperationsCentralBase>()
    .AddData(connectionString);
    //.AddDbContext<MaritimeContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Data")));

using var host = builder.Build();


var manageProgram = host.Services.GetService<OperationsCentralBase>();
var vesselService = host.Services.GetService<VesselService>();

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
            //stateFunction = manageProgram.AddVessel();
            break;
        case "CO":
            //stateFunction = manageProgram.AddOwner();
            break;
        case "RV":
            //stateFunction = vesselService.ShowAllAsync();
            vesselService.ShowAllAsync();
            break;
        case "RO":
            //stateFunction = manageProgram.ShowOwners();
            break;
        case "UV":
            //stateFunction = manageProgram.UpdateVessel();
            break;
        case "UO":
            //stateFunction = manageProgram.UpdateOwner();
            break;
        case "DV":
            //stateFunction = manageProgram.DeleteVessel();
            break;
        case "DO":
            //stateFunction = manageProgram.DeleteOwner();
            break;
        case "A":
            //manageProgram.AssignVesselToOwner();
            break;
        default:
            isProgramOn = false;
            Console.WriteLine("Option not available!!\ntry again...");
            break;
    }

    //manageProgram.BreakConcludeOperation(stateFunction);

    /*
    if (inputTypeOperation == "CV" || inputTypeOperation == "CO" || inputTypeOperation == "RV" || inputTypeOperation == "RO" || inputTypeOperation == "UV"
        || inputTypeOperation == "UO" || inputTypeOperation == "DV" || inputTypeOperation == "DO" || inputTypeOperation == "A")
    {
        manageProgram.ShowOwners();
        Console.WriteLine("\n\n");
        manageProgram.ShowVessels();
        manageProgram.BreakConcludeOperation("");
    }
    */

}

