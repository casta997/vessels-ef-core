using _001_aTestDI.GlobalInterfaces;

namespace _001_aTestDI.Services;

internal class EmailService : INotification
{
    public void Send(string msg)
    {
        Console.WriteLine(msg + " - Email send");
    }
}
