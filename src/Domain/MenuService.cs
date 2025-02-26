namespace Domain;

public class MenuService(IVesselService vesselService) : IMenuService
{
    public async Task RunAsync(Func<string> inputProvider, Action<string> outputProvider)
    {
        outputProvider.Invoke("MENUMENUMENUMENUMENUMENUMENUMENUMENUMENU");

        var choice = inputProvider.Invoke();

        switch (choice)
        {
            default:
                await vesselService.ShowAsync(outputProvider);
                break;
        }
    }
}