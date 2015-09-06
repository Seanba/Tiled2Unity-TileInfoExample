using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Tiled2Unity.CustomTiledImporter]
public class CustomImporter_StrategyTiles : Tiled2Unity.ICustomTiledImporter
{

    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {
        if (customProperties.ContainsKey("Terrain"))
        {
            // Add the terrain tile game object
            StrategyTile tile = gameObject.AddComponent<StrategyTile>();
            tile.TileType = customProperties["Terrain"];
            tile.TileNote = customProperties["Note"];
        }
    }

    public void CustomizePrefab(GameObject prefab)
    {
        // Do nothing
    }
}
