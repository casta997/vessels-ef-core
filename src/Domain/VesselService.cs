using Data.Entities;
using Data.Repositories;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Domain;

public class VesselService(IVesselRepository vesselRepository, ILogger<VesselService> loggerService) : IRecordManagerService<VesselService>
{
    private readonly IVesselRepository _vesselRepository = vesselRepository;

    private readonly ILogger<VesselService> _loggerService = loggerService;

    private string InsertImoNumber()
    {
        var imoNumber = "";
        var existImoNumber = false;
        while (!existImoNumber)
        {
            //Console.Clear();
            _loggerService.LogInformation("Insert IMO Number of the vessel:");
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
        _loggerService.LogInformation($"{errorMessage}\nPress any key to continue...");
        Console.ReadKey();
        //Console.Clear();
    }

    public void ShowAll()
    {
        var vessels = _vesselRepository.ReadVessels();

        if (vessels.Count > 0)
        {
            var msgVesselInformation = new StringBuilder();
            msgVesselInformation.AppendLine("*****Vessel Information*****");
            msgVesselInformation.AppendLine($"\n Id \t| ImoNumber \t| OwnerId");
            foreach (var ve in vessels)
            {
                msgVesselInformation.AppendLine(ve.ToString());
            }
            _loggerService.LogInformation(msgVesselInformation.ToString());
        }
        else
            _loggerService.LogInformation("There are no Vessels!");
    }

    public void Add()
    {
        var imoNumber = InsertImoNumber();

        var vessel = new Vessel()
        {
            ImoNumber = imoNumber
        };

        if (_vesselRepository.CreateVessel(vessel) > 0)
            _loggerService.LogInformation("Vessel modified successfully.");

        if (_vesselRepository.CreateVessel(vessel) <= 0)
            _loggerService.LogError("No changes were made to the Vessel.\nPlease try again, or contact the Admin for assistance.");
    }

    public void ModifyValues()
    {
        ShowAll();
        if (_vesselRepository.ReadVessels().Count > 0)
        {
            _loggerService.LogInformation("\nInsert id of vessel to modify:");
            string inputConsole = Console.ReadLine() ?? string.Empty; ;
            bool idIsParsed = int.TryParse(inputConsole, out int idVessel);

            if (!idIsParsed || idVessel <= 0)
                _loggerService.LogWarning("Id must be a positive number");
            else if (!_vesselRepository.CheckIfIdExist(idVessel))
                _loggerService.LogWarning("Id inserted doesn't exist");

            if (idIsParsed && idVessel > 0 && _vesselRepository.CheckIfIdExist(idVessel))
            {
                _loggerService.LogInformation("\nInsert imo number to change:");
                var imoNumber = Console.ReadLine() ?? string.Empty;

                if (_vesselRepository.UpdateImoNumber(idVessel, imoNumber) > 0)
                    _loggerService.LogInformation("Vessel modified successfully.");

                if (_vesselRepository.UpdateImoNumber(idVessel, imoNumber) <= 0)
                    _loggerService.LogError("No changes were made to the Vessel.\nPlease try again, or contact the Admin for assistance.");
            }

        }
    }

    public void Remove()
    {
        ShowAll();
        if (_vesselRepository.ReadVessels().Count > 0)
        {
            _loggerService.LogInformation("\nInsert id of vessel to delete:");
            string inputConsole = Console.ReadLine() ?? string.Empty; ;
            bool idIsParsed = int.TryParse(inputConsole, out int idVessel);

            if (idIsParsed && idVessel > 0)
            {
                _loggerService.LogInformation("Are you sure to delete this vessel? Y / N");
                var answerDeleteVessel = Console.ReadKey();

                if ((Char.ToUpper(answerDeleteVessel.KeyChar) != 'Y'))
                    _loggerService.LogInformation("\"No changes were made to the Vessel.");
                else if (!_vesselRepository.CheckIfIdExist(idVessel))
                    _loggerService.LogWarning("Id inserted doesn't exist");
                else if (_vesselRepository.DeleteVessel(idVessel) <= 0)
                    _loggerService.LogError("No changes were made to the Vessel.\nPlease try again, or contact the Admin for assistance.");

                if (
                        (Char.ToUpper(answerDeleteVessel.KeyChar) == 'Y') &&
                        (_vesselRepository.CheckIfIdExist(idVessel)) &&
                        (_vesselRepository.DeleteVessel(idVessel) > 0)
                    )
                    _loggerService.LogInformation("Vessel deleted successfully.");
            }
            else
                _loggerService.LogWarning("Id must be a positive number");
        }
    }

    public void AssociateManyToThis()
    {
        //Not implemented yet. Can be useful for future tasks
    }
}

