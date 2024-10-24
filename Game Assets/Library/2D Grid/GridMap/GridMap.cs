using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class GridMap
{
    [SerializeField] private int sizeX = 5, sizeY = 5;
    [SerializeField] private GridTile[] tiles = new GridTile[25];
    public void InitializeMap(int sizeX, int sizeY)
    {
        tiles = new GridTile[sizeX * sizeY];
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        for (int x = 0; x < sizeX; x++)
            for (int y = 0; y < sizeY; y++)
                tiles[x * sizeY + y] = new GridTile(x, y);
    }
    private bool IsOutBounds(int x, int y)
    {
        return x >= sizeX || y >= sizeY || x < 0 || y < 0;
    }
    public GridTile GetTile(int x, int y)
    {
        return tiles[x * sizeY + y];
    }
    public GridTile[] GetAllGridTiles()
    {
        return tiles;
    }
    public Vector2Int GetSize()
    {
        return new Vector2Int(sizeX, sizeY);
    }
    public List<Vector2Int> GetArea(Vector2Int pos1, Vector2Int pos2)
    {
        List<Vector2Int> area = new List<Vector2Int>();
        int startX = Mathf.Min(pos1.x, pos2.x);
        int startY = Mathf.Min(pos1.y, pos2.y);
        int endX = Mathf.Max(pos1.x, pos2.x);
        int endY = Mathf.Max(pos1.y, pos2.y);
        for (int x = startX; x <= endX; x++)
            for (int y = startY; y <= endY; y++)
                area.Add(new Vector2Int(x, y));
        return area;
    }
    public bool CanTakeArea(Vector2Int pos1, Vector2Int pos2)
    {
        return !GetArea(pos1, pos2)
        .Exists(pos => IsOutBounds(pos.x, pos.y) || !GetTile(pos.x, pos.y).CanBuild());
    }
}
public static class GridMapModifyMethods
{
    public static void SetWalkableOfTiles(this GridMap gridMap, Vector2Int pos1, Vector2Int pos2, bool isWalkable)
    {
        gridMap.GetArea(pos1, pos2)
          .ForEach(pos => gridMap.GetTile(pos.x, pos.y)
          .SetWalkable(isWalkable));
    }
    public static void SetBuildableOfTiles(this GridMap gridMap, Vector2Int pos1, Vector2Int pos2, bool isBuildable)
    {
        gridMap.GetArea(pos1, pos2)
        .ForEach(pos => gridMap.GetTile(pos.x, pos.y)
        .SetBuildable(isBuildable));
    }
    public static void ResetMap(this GridMap gridMap, int sizeX, int sizeY)
    {
        gridMap.InitializeMap(sizeX, sizeY);
    }
    public static void ResetMap(this GridMap gridMap)
    {
        gridMap.InitializeMap(gridMap.GetSize().x, gridMap.GetSize().x);
    }
}