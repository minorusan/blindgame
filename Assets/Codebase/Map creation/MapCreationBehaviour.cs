using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public struct IJ
    {
        public int x;
        public int y;
    }

    public class Node
    {
        public IJ coordinates;
        public bool isEnterPoint;
        public bool isExitPoint;
        public bool isObstacle;
        public bool isCollectable;

        public bool visited;
        public TileInteractionBase interaction;
    }

    public class MapCreationBehaviour : MonoBehaviour
    {
        public List<Node> nodes;
        public IJ startPositionIJ;
        public IJ centerPoint;
        public int collectablesCount;

        public MapProviderBase mapProvider;

        void Awake()
        {
            var map = mapProvider.GetMap();
            centerPoint = new IJ { x = Mathf.RoundToInt(map.GetLength(0) / 2), y = Mathf.RoundToInt(map.GetLength(1) / 2) };
            nodes = new List<Node>();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    var newNodeDefinition = map[i, j].ToTileDefinition(mapProvider);
                    GameObject toInstantiate = newNodeDefinition.prefab;

                    var newGridCell = Instantiate(toInstantiate, transform);
                    var localPosition = new Vector3(i, 0, j);

                    var newNode = new Node()
                    {
                        isCollectable = map[i, j] == mapProvider.collectableColor,
                        isObstacle = map[i, j] == mapProvider.obstacleColor,
                        isEnterPoint = map[i, j] == mapProvider.enterpointColor,
                        isExitPoint = map[i, j] == mapProvider.exitpointColor,
                        interaction = newNodeDefinition.interaction
                    };

                    newNode.coordinates = new IJ() { x = i, y = j };
                    nodes.Add(newNode);
                    if (newNode.isCollectable)
                    {
                        collectablesCount++;
                    }
                    if (newNode.isEnterPoint)
                    {
                        startPositionIJ = newNode.coordinates;
                    }
                    newGridCell.transform.localPosition = localPosition;
                }
            }

        }

        public Node GetNode(IJ coordinates)
        {
            var result = nodes.FirstOrDefault(node => node.coordinates.x == coordinates.x && node.coordinates.y == coordinates.y);
            return result;
        }
    }
}