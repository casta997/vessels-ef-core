using Microsoft.Extensions.Logging;

namespace Domain;

public interface IRecordManagerService<in T> where T : class
{
    void Add();
    void ShowAll();
    void ModifyValues();
    void Remove();
    void AssociateManyToThis();
}
