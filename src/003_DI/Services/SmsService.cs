using _003_DI.IPersonalServices;

namespace _003_DI.Services;

internal class SmsService : ISmsService
{
    public void Send(string message)
    {
        Console.WriteLine(message + " by sms");
    }
}
