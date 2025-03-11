using _001_DI.IServices;

namespace _001_DI.Services;

internal class EmailService : INotification
{
    public void Send(string message)
    {
        Console.WriteLine(message + " by email");
    }
}
