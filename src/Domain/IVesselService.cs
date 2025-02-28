namespace Domain;

public interface IVesselService
{
    Task ShowAllAsync();

    Task RegisterOnlyOne(Func<string> inputProvider, Action<string> outputProvider);
}
