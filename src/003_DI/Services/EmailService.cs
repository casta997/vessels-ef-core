using _003_DI.IPersonalServices;

namespace _003_DI.Services;

internal class EmailService : IEmailService
{
    public void Send(string message)
    {
        Console.WriteLine(message + " by email");
    }
}
