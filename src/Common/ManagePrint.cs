using Domain;
using Microsoft.Extensions.Logging;
namespace Common;

public class ManagePrint(IRecordManagerService<OwnerService> ownerService) : IManagePrint
{
    public void StopAndClearAndPrintMessageDynamic(int levelClear, string msg, int logLevel)
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

    private void PrintLog(string msg, int logLevel)
    {
        /*
        var typeLogger = ownerServiceownerService.GetILogerToPrintLog();
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
        */
    }
}
