using System;
using System.Linq;
using UnityEngine;
using Core;


public static class Extentions
{
    public static TileDefinition ToTileDefinition(this Color color, MapProviderBase mapProvider)
    {
        return mapProvider.tiles.FirstOrDefault(x => x.color == color);
    }
}