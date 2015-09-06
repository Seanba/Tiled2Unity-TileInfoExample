using UnityEngine;
using System.Collections;
using System.Text;

public class StrategyTileInfoText : MonoBehaviour
{
    private UnityEngine.UI.Text uiText;

    private void Start()
    {
        this.uiText = GetComponent<UnityEngine.UI.Text>();
    }

	private void Update()
    {
	    if (Input.GetMouseButtonUp(0))
        {
            // Do a raycast to find our selected tile
            Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            Vector2 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, 0);
            if (hit)
            {
                StrategyTile tile = hit.collider.gameObject.GetComponent<StrategyTile>();
                tile.NumberOfClicks++;

                StringBuilder info = new StringBuilder();
                info.AppendFormat("Tile: {0}", tile.TileType);
                info.AppendLine();
                info.Append(tile.TileNote);
                info.AppendLine();
                info.AppendFormat("Clicks: {0}", tile.NumberOfClicks);
                this.uiText.text = info.ToString();
            }
            else
            {
                this.uiText.text = "No tile selected";
            }

            // Place the cursor
            GameObject cursor = GameObject.FindGameObjectWithTag("Cursor");
            position.x -= position.x % 16;
            position.y -= position.y % 16;
            cursor.transform.position = position;
           
        }
	}
}
