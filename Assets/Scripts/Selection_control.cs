using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Selection_control : MonoBehaviour
{

    public bool selectionStarted = false;
    public GameObject selectionCollider;
    GameObject inistiatedCollider;
    int count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public Tilemap tilemap;
    public TileBase tileToInput;
    public TileBase whiteTile;
    private bool isMouseButtonDown = false;
    public string mode = "";

    private void Update()
    {
        if (mode == "select")
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMouseButtonDown = true;
                PlaceTile();
            }

            // Check for mouse button up
            if (Input.GetMouseButtonUp(0))
            {
                isMouseButtonDown = false;
            }

            // Continuously place tiles while mouse button is held down
            if (isMouseButtonDown)
            {
                PlaceTile();
            }
        }
        else if (mode == "remove")
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMouseButtonDown = true;
                RemoveTile();
            }

            // Check for mouse button up
            if (Input.GetMouseButtonUp(0))
            {
                isMouseButtonDown = false;
            }

            // Continuously place tiles while mouse button is held down
            if (isMouseButtonDown)
            {
                RemoveTile();
            }
        }
        // Check for mouse button down

    }

    private void PlaceTile()
    {
        // Convert mouse position to world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Convert world position to cell position
        Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);

        // Set the tile at the cell position

        if (IsWithinBoundaries(cellPosition))
        {
            // Set the tile at the cell position
            tilemap.SetTile(cellPosition, tileToInput);
        }
       
    }

    private void RemoveTile()
    {
        // Convert mouse position to world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Convert world position to cell position
        Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);

        // Set the tile at the cell position
        tilemap.SetTile(cellPosition, null);
    }

    public void initiate()
    {
        if (count == 0)
        {
            inistiatedCollider = Instantiate(selectionCollider);
        }
        selectionStarted = true;
        mode = "select";

    }

    public void erase()
    {

        mode = "remove";
        selectionStarted = true;

    }

    public void clear()
    {
        end();
        foreach (Vector3Int cellPosition in tilemap.cellBounds.allPositionsWithin)
        {

            // Replace the tile with the replacement tile
            tilemap.SetTile(cellPosition, null);

        }
    }
    public void end()
    {
        Destroy(inistiatedCollider.gameObject);
        count++;
        mode = "";
        selectionStarted = false;
    }

    public void startGame()
    {
        replaceAll();
    }
    public void replaceAll()
    {
        foreach (Vector3Int cellPosition in tilemap.cellBounds.allPositionsWithin)
        {
            // Check if the current cell contains the original tile
            if (tilemap.GetTile(cellPosition) == tileToInput)
            {
                // Replace the tile with the replacement tile
                tilemap.SetTile(cellPosition, whiteTile);
            }
        }
    }

    public void retry()
    {
        foreach (Vector3Int cellPosition in tilemap.cellBounds.allPositionsWithin)
        {
            // Check if the current cell contains the original tile
            if (tilemap.GetTile(cellPosition) != whiteTile)
            {
                // Replace the tile with the replacement tile
                tilemap.SetTile(cellPosition, null);
            }
        }
    }

    public GameObject boundaryContainer;
   

   

    private bool IsWithinBoundaries(Vector3Int cellPosition)
    {
        // Check if the cell position is within the boundaries defined by the colliders
        Collider2D[] colliders = boundaryContainer.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider.OverlapPoint(tilemap.CellToWorld(cellPosition)))
            {
                return false;
            }
        }
        return true;

    }
}
