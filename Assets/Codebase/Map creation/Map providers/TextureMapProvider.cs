using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu]
    public class TextureMapProvider : MapProviderBase
    {
        public Texture2D inputTexture;

        public override void SetMapIndex(int index)
        {
            var path = "Textures/Maps/" + index;
            Debug.Log("Loading texture for path:" + path);
            inputTexture = Resources.Load<Texture2D>(path);
            if (inputTexture == null)
            {
                SetMapIndex(0);
            }
        }

        public override Color[,] GetMap()
        {
            var mapArray = new Color[inputTexture.width, inputTexture.height];
            for (int i = 0; i < inputTexture.width; i++)
            {
                for (int j = 0; j < inputTexture.height; j++)
                {
                    var color = inputTexture.GetPixel(i, j);
                    mapArray[i, j] = color;
                }
            }

            return mapArray;
        }
    }
}