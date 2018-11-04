using System;
using System.Linq;
using UnityEngine;
using Core;


public static class Extentions
{
    public static TileDefinition ToTileDefinition(this Color color, MapProviderBase mapProvider)
    {
        var result = mapProvider.tiles.FirstOrDefault(x => x.color == color);
        if (result == null)
        {
            return ToTileDefinition(Color.white, mapProvider);
        }
        return result;
    }
}