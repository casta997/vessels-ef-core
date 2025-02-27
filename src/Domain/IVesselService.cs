namespace Domain;

public interface IVesselService
{
    Task ShowAllAsync(Action<string> outputProvider);

    Task RegisterOnlyOne(Action<string> outputProvider);
}
