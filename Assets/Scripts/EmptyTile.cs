using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Empty Tile", menuName = "Tiles/Empty Tile")]
public class EmptyTile : TileBase
{
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        // Set the tile's collider type to Grid (this will prevent Unity from generating colliders for it)
        tileData.colliderType = Tile.ColliderType.Grid;
    }
}
