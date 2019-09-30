﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySizeController : MonoBehaviour
{
    public float oldWidth = 544, oldHeight = 135;

    RectTransform parent;
    GridLayoutGroup grid;

    // Use this for initialization
    void Start()
    {
        parent = gameObject.GetComponent<RectTransform>();
        grid = gameObject.GetComponent<GridLayoutGroup>();

        resize();
    }

    private void LateUpdate()
    {
        resize();
    }

    void resize()
    {
        // set size
        float aspectWidth = parent.rect.width / oldWidth;
        float aspectHeight = parent.rect.height / oldHeight;

        grid.cellSize = new Vector2(grid.cellSize.x * aspectWidth, grid.cellSize.y * aspectHeight);

        grid.padding.left = (int)(grid.padding.left * aspectWidth);
        grid.padding.right = (int)(grid.padding.right * aspectWidth);
        grid.padding.top = (int)(grid.padding.top * aspectHeight);
        grid.padding.bottom = (int)(grid.padding.bottom * aspectHeight);

        grid.spacing = new Vector2(grid.spacing.x * aspectWidth, grid.spacing.y * aspectHeight);

        // save width and height
        oldWidth = parent.rect.width;
        oldHeight = parent.rect.height;
    }
}
