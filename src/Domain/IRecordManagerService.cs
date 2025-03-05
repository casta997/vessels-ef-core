namespace Domain;

public interface IRecordManagerService<in T> where T : class
{
    void Add();
    void ShowAll();
    void ModifyValues();
    void Remove();
}
