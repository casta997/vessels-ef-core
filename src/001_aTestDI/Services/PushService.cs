using _001_aTestDI.GlobalInterfaces;

namespace _001_aTestDI.Services;

internal class PushService : INotification
{
    public void Send(string msg)
    {
        Console.WriteLine(msg + " - Push send");
    }
}
