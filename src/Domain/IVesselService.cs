namespace Domain;

public interface IVesselService
{
    Task ShowAsync(Action<string> outputProvider);
}
