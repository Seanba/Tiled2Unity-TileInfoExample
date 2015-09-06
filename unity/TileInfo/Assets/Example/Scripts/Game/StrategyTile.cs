using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StrategyTile : MonoBehaviour
{
    private static readonly IDictionary<string, Color> TypeToColor = new Dictionary<string, Color>()
    {
        { "Bridge", new Color(0.5f, 0, 0f) },
        { "Grass", new Color(0.9f, 0.6f, 0) },
        { "Mountain", Color.red },
        { "Tree", new Color(0, 0.5f, 0) },
        { "Wall", Color.black },
        { "Water", Color.blue },
    };

    public string TileNote = "<no note>";
    public string TileType = "<no type>";
    public int NumberOfClicks = 0;

    private void OnDrawGizmosSelected()
    {
        Vector3 position = this.transform.position;
        position.x += 8;
        position.y -= 8;

        Color drawColor;
        if (!StrategyTile.TypeToColor.TryGetValue(this.TileType, out drawColor))
        {
            drawColor = Color.black;
        }


        Color fillColor = drawColor;
        fillColor.a = 0.25f;

        Gizmos.color = fillColor;
        Gizmos.DrawCube(position, new Vector3(16, 16, 0));

        Gizmos.color = drawColor;
        Gizmos.DrawWireCube(position, new Vector3(16, 16, 0));
    }

}
