namespace Domain;

public interface IMenuService
{
    Task RunAsync(Func<string> inputProvider, Action<string> outputProvider);
}
