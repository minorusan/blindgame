using UnityEngine;

[CreateAssetMenu]
public class TileDefinition : ScriptableObject
{
    public Color color;
    public GameObject prefab;
    public TileInteractionBase interaction;
}
