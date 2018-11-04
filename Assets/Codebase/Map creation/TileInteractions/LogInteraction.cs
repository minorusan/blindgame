using Core;
using UnityEngine;

[CreateAssetMenu]
public class LogInteraction : TileInteractionBase
{
    public string message;
    public ELogType logType;

    public override void PerformInteraction(Vector3 position)
    {
        ServiceProvider.GetService<CommandExecutor>().EnqueueCommand(new LogCommand(message, logType));
    }
}