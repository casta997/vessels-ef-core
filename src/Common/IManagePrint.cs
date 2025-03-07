namespace Common;

public interface IManagePrint
{
    void StopAndClearAndPrintMessageDynamic(int levelClear, string msg, int logLevel);
}
