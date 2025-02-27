namespace Domain;

public class MenuService(IVesselService vesselService) : IMenuService
{
    public async Task RunAsync(Func<string> inputProvider, Action<string> outputProvider)
    {
        //outputProvider.Invoke("MENUMENUMENUMENUMENUMENUMENUMENUMENUMENU");
        Console.WriteLine("Scegli un azione:");

        var choice = inputProvider.Invoke();

        switch (choice)
        {
            case "a":
                await vesselService.RegisterOnlyOne(outputProvider);
                break;
            default:
                await vesselService.ShowAllAsync(outputProvider);
                break;
        }
    }
}