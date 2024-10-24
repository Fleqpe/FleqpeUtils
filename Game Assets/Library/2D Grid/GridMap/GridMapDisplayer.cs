using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GridMapDisplayer : SingletonManager<GridMapDisplayer>
{
    [SerializeField] private Tilemap defaultTilemap;
    [SerializeField] private Tilemap walkableInfoTilemap;
    [SerializeField] private Tilemap buildableInfoTilemap;
    [SerializeField] private Tile walkableTile, notWalkableTile;
    [SerializeField] private Tile buildableTile, notBuildableTile;
    [SerializeField] private GridMap gridMap = new GridMap();
    [SerializeField] private List<TileBase> tiles = new List<TileBase>();
    public Tilemap GetTilemap() => defaultTilemap;
    public GridMap GetGridMap() => gridMap;
    public Tilemap GetWalkableInfoTilemap() => walkableInfoTilemap;
    public void DeleteMap()
    {
        buildableInfoTilemap.ClearAllTiles();
        walkableInfoTilemap.ClearAllTiles();
        defaultTilemap.ClearAllTiles();
        SyncTilemapToGrid();
    }
    public void SyncGridToTilemap()
    {
        for (int x = 0; x < gridMap.GetSize().x; x++)
        {
            for (int y = 0; y < gridMap.GetSize().y; y++)
            {
                GridTile tile = gridMap.GetTile(x, y);
                Vector3Int position = new Vector3Int(x, y, 0);
                walkableInfoTilemap.SetTile(position, tile.CanWalk() ? walkableTile : notWalkableTile);
                buildableInfoTilemap.SetTile(position, tile.CanBuild() ? buildableTile : notBuildableTile);
            }
        }
    }
    public void SyncTilemapToGrid()
    {
        foreach (Vector3Int value in defaultTilemap.cellBounds.allPositionsWithin)
            if (value.x < 0 || value.y < 0)
                defaultTilemap.SetTile(value, null);
        defaultTilemap.CompressBounds();
        gridMap.ResetMap(defaultTilemap.cellBounds.size.x, defaultTilemap.cellBounds.size.y);
        defaultTilemap.RefreshAllTiles();
        for (int x = 0; x < gridMap.GetSize().x; x++)
            for (int y = 0; y < gridMap.GetSize().y; y++)
                SyncTile(x, y);
    }
    private void SyncTile(int x, int y)
    {
        defaultTilemap.RefreshAllTiles();
        GridTile tile = gridMap.GetTile(x, y);

        TileBase defaultTileBase = defaultTilemap.GetTile(new Vector3Int(x, y, 0));
        TileBase walkableTileBase = walkableInfoTilemap.GetTile(new Vector3Int(x, y, 0));
        TileBase buildableTileBase = buildableInfoTilemap.GetTile(new Vector3Int(x, y, 0));

        tile.SetWalkable(walkableTileBase == walkableTile);
        tile.SetBuildable(buildableTileBase == buildableTile);

        int tileIndex = tiles.IndexOf(defaultTileBase);
        tile.SetIndex(tileIndex);

        Vector3Int cellPosition = new Vector3Int(x, y, 0);

        if (tileIndex != -1)
        {
            walkableInfoTilemap.SetTile(cellPosition, notWalkableTile);
            buildableInfoTilemap.SetTile(cellPosition, notBuildableTile);
        }
        else
        {
            walkableInfoTilemap.SetTile(cellPosition, null);
            buildableInfoTilemap.SetTile(cellPosition, null);
        }
    }
}
