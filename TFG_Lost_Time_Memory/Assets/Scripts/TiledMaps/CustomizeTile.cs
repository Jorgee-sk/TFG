using UnityEngine;
using UnityEngine.Tilemaps;

public class CustomizeTile : MonoBehaviour
{
    public Tilemap tilemap;
    private Tile _tile;
    public TiledMapCustom tiledMapCustom;
    
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        _tile = (Tile)tilemap.GetTile(tilemap.origin);

        TileData tileData = new TileData();
        tiledMapCustom.GetTileData(tilemap.origin, null, ref tileData);
        RefreshMap();
    }
 
    private void RefreshMap()
    {
        if (tilemap != null)
        {
            tilemap.RefreshAllTiles();
        }
    }
}