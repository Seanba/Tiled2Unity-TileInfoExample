using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

class RPGTileInfoText : MonoBehaviour
{
    private UnityEngine.UI.Text uiText;

    private void Start()
    {
        this.uiText = GetComponent<UnityEngine.UI.Text>();
        this.uiText.text = "Click on map";
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Do a raycast to find our selected tile
            Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            Vector2 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Ignore the default mask
            int layerMask = ~(1 << LayerMask.NameToLayer("Default"));
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, 0, layerMask);
            if (hit)
            {
                string layerName = LayerMask.LayerToName(hit.collider.gameObject.layer);
                this.uiText.text = String.Format("Tile type: {0}", layerName);
            }
            else
            {
                this.uiText.text = "No tile collision";
            }

            // Place the cursor
            GameObject cursor = GameObject.FindGameObjectWithTag("Cursor");
            position.x -= position.x % 16;
            position.y -= position.y % 16;
            cursor.transform.position = position;
        }
    }

}

