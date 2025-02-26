using Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Worker(ILogger<Worker> logger, IMenuService menuService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await menuService.RunAsync(Console.ReadLine, Print);
        }
    }

    private void Print(string message)
    {
        logger.LogInformation(message);
    }
}
