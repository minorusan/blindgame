using UnityEngine;

namespace Core
{
    public abstract class MapProviderBase : ScriptableObject
    {
        public TileDefinition[] tiles;
        public Color obstacleColor;
        public Color enterpointColor;
        public Color exitpointColor;
        public Color collectableColor;

        public abstract Color[,] GetMap();
        public abstract void SetMapIndex(int index);
    }

}