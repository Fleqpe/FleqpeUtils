using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;
[DefaultExecutionOrder(9)]
public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance;
    public GridLayout gridLayout;
    public Transform buildingsParent;
    public Tilemap buildInfoTilemap, walkInfoTilemap;
    public TileBase takenTile, emptyTile, notWalkable, walkableTile;
    public static Action onInitialize, onPlace, onReplace, onPlaceCancel;
    void Awake()
    {
        SetSingleton();
    }
    private void SetSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #region Tilemap Management
    private static void SetTilesOnArea(BoundsInt area, TileBase tileBase, Tilemap tilemap)
    {
        TileBase[] arr = new TileBase[area.size.x * area.size.y];

        for (int i = 0; i < arr.Length; i++)
            arr[i] = tileBase;

        tilemap.SetTilesBlock(area, arr);
    }
    public void ClearArea(BoundsInt area, bool isWalkable)
    {
        SetTilesOnArea(area, emptyTile, buildInfoTilemap);
        if (!isWalkable)
            SetTilesOnArea(area, walkableTile, walkInfoTilemap);
    }
    public void TakeArea(BoundsInt area, bool isWalkable)
    {
        SetTilesOnArea(area, takenTile, buildInfoTilemap);
        if (!isWalkable)
            SetTilesOnArea(area, notWalkable, walkInfoTilemap);
    }
    #endregion
    #region Building Management
    public async UniTaskVoid InitializeWithObject(GameObject building, Vector3 pos)
    {
        await UniTask.DelayFrame(1);
        pos.z = 0;
        Vector3Int cellPos = gridLayout.WorldToCell(pos);
        Vector3 localPos = gridLayout.CellToLocalInterpolated(cellPos);
        Instantiate(building, localPos, Quaternion.identity, buildingsParent);
        onInitialize?.Invoke();
    }
    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] tileArray = buildInfoTilemap.GetTilesBlock(area);
        foreach (TileBase tile in tileArray)
            if (tile == takenTile || tile == null)
                return false;
        return true;
    }
    #endregion
}
