using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class GridTile
{
    [SerializeField] private int x, y;
    [SerializeField] private int index;
    [SerializeField] private bool isWalkable, isBuildable;
    public Vector2Int GetPosition() => new Vector2Int(x, y);
    public int GetTileIndex() => index;
    public bool CanWalk() => isWalkable;
    public bool CanBuild() => isBuildable;
    public GridTile(int x, int y, bool isWalkable = false, bool isBuildable = false)
    {
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;
        this.isBuildable = isBuildable;
    }
    public Vector2 GetPositionOnTilemap(Tilemap tilemap)
    {
        Vector3 localPos = tilemap.CellToLocalInterpolated(new Vector3(x, y));
        return localPos;
    }
    public void SetWalkable(bool isWalkable)
    {
        this.isWalkable = isWalkable;
    }
    public void SetBuildable(bool isBuildable)
    {
        this.isBuildable = isBuildable;
    }
    public void SetIndex(int index)
    {
        this.index = index;
    }
}
