using _003_DI.IPersonalServices;

namespace _003_DI.Services;

internal class PushService : IPushService
{
    public void Send(string message)
    {
        Console.WriteLine(message + " by push");
    }
}
