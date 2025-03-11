using _002_DI.IPersonalServices;

namespace _002_DI.Services;

internal class PushService : IPushService
{
    public void Send(string message)
    {
        Console.WriteLine(message + " by push");
    }
}
