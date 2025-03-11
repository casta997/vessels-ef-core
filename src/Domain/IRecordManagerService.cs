using Microsoft.Extensions.Logging;

namespace Domain;

public interface IRecordManagerService<T> where T : class
{
    void Add();
    void ShowAll();
    void ModifyValues();
    void Remove();
    void AssociateManyToThis();
    //Logger GetLogger()
}
