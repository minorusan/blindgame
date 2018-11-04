using Core;
using UnityEngine;

[CreateAssetMenu]
public class AudioInteraction : TileInteractionBase
{
    public AudioClip tileInteraction;

    public override void PerformInteraction(Vector3 position)
    {
        ServiceProvider.GetService<CommandExecutor>().EnqueueCommand(new PlayAudioCommand(tileInteraction, position));
    }
}