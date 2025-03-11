using Application.ManageProgram;
using Data.Entities;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;



var builder = Host.CreateApplicationBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("MaritimeDb")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services
    .AddTransient<OperationsCentralBase>()
    .AddData(connectionString)
    .AddLogging(builder => builder.AddConsole())
    .AddCommon()
    .AddDomain();

using var host = builder.Build();

/*
using (MaritimeContext vmc = host.Services.GetService<>())
{
    vmc.Database.EnsureCreated();
}
*/
/*
var dbContext = host.Services.GetService<MaritimeContext>();


var list = dbContext.Vessels
    .Where(x => x.Id == 1)
    .Where(x => x.Id == 1)
    .Select(x => x.Id)
    .Where(x => x % 2 == 0)
    .ToList();
*/

var manageProgram = host.Services.GetService<OperationsCentralBase>();
var vesselService = host.Services.GetService<IRecordManagerService<VesselService>>();
var ownerService = host.Services.GetService<IRecordManagerService<OwnerService>>();
var loggerService = host.Services.GetService<ILogger<Program>>();

var isProgramOn = true;
var menu = new StringBuilder();
menu.AppendLine("---------------------Managing Vessels---------------------");
menu.AppendLine("Select 1 operation:");
menu.AppendLine("CV.- Create a new vessel.");
menu.AppendLine("CO.- Create a new owner.");
menu.AppendLine("RV.- Display the list of vessels.");
menu.AppendLine("RO.- Display the list of owners.");
menu.AppendLine("UV.- Update the details of an existing vessel.");
menu.AppendLine("UO.- Update the details of an existing owner.");
menu.AppendLine("DV.- Delete a vessel.");
menu.AppendLine("DO.- Delete an owner.");
menu.AppendLine("A.- Assign a vessel to an owner.");

while (isProgramOn)
{
    loggerService.LogInformation(menu.ToString());

    string inputTypeOperation = Console.ReadLine();
    Console.Clear();
    string stateFunction = "";

    switch (inputTypeOperation)
    {
        case "CV":
            vesselService.Add();
            break;
        case "CO":
            ownerService.Add();
            break;
        case "RV":
            vesselService.ShowAll();
            break;
        case "RO":
            ownerService.ShowAll();
            break;
        case "UV":
            vesselService.ModifyValues();
            break;
        case "UO":
            ownerService.ModifyValues();
            break;
        case "DV":
            vesselService.Remove();
            break;
        case "DO":
            ownerService.Remove();
            break;
        case "A":
            ownerService.AssociateManyToThis();
            break;
        default:
            isProgramOn = false;
            loggerService.LogInformation("Option not available!!\ntry again...");
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

