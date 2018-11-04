using UnityEngine;

public abstract class TileInteractionBase : ScriptableObject
{
    public abstract void PerformInteraction(Vector3 position);
}
