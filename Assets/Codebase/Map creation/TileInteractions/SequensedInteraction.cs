using Core;
using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class SequensedInteraction : TileInteractionBase
{
    public TileInteractionBase[] interactions;
    [Tooltip("Each interaction with tile will be played after delay." +
             " First interaction goes without delay")]
    public float delay;

    public override void PerformInteraction(Vector3 position)
    {
        Routiner.Go(PlaySequence(position));
    }

    private IEnumerator PlaySequence(Vector3 position)
    {
        var waitHandle = new WaitForSeconds(delay);
        for (int i = 0; i < interactions.Length; i++)
        {
            interactions[i].PerformInteraction(position);
            yield return waitHandle;
        }
    }
}