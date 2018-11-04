using UnityEngine;
using Core;

public enum ELogType
{
    Log, Error, Warning
}

public class LogCommand : ICommand
{
    private string _logText;
    private ELogType _type;

    public LogCommand(string message, ELogType logType)
    {
        _logText = message;
        _type = logType;
    }

    public void Execute()
    {
        switch (_type)
        {
            case ELogType.Error:
                {
                    Debug.LogError(_logText);
                    break;
                }
            case ELogType.Warning:
                {
                    Debug.LogWarning(_logText);
                    break;
                }
            case ELogType.Log:
                {
                    Debug.Log(_logText);
                    break;
                }
        }
    }
}