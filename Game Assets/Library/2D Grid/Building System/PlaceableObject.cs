using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
public class PlaceableObject : MonoBehaviour
{
    [SerializeField] private bool placed, canWalkThrough;
    [SerializeField] private Vector2Int size;
    private GridMap gridMap;
    private Tilemap tilemap;
    void Awake()
    {
        SetMaps();
        Movement().Forget();
    }
    private void LateUpdate()
    {
        if (!placed && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
            Place();
    }
    public void Load(Vector2Int cellPos)
    {
        gridMap.SetBuildableOfTiles(cellPos, GetAreaEnd(cellPos), false);
        placed = true;
    }
    private Vector2Int GetAreaEnd(Vector2Int pos)
    {
        return pos + size - Vector2Int.one;
    }
    private void SetMaps()
    {
        gridMap = GridMapDisplayer.Instance.GetGridMap();
        tilemap = GridMapDisplayer.Instance.GetTilemap();
    }
    private async UniTask Movement()
    {
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            await UniTask.WaitForEndOfFrame().AttachExternalCancellation(destroyCancellationToken);
            Vector2Int mouseCellPos = tilemap.GetCellPositionOfMouse();
            Vector2Int objectPos = GetCellPositionOfGameObject();
            if (mouseCellPos != objectPos && !placed && CanMoveToPosition(mouseCellPos))
            {
                MarkTemporaryArea(mouseCellPos, objectPos);
                await MoveToPosition(mouseCellPos).AttachExternalCancellation(destroyCancellationToken);
            }
        }
    }
    private void MarkTemporaryArea(Vector2Int mouseCellPos, Vector2Int objectPos)
    {
        gridMap.SetBuildableOfTiles(objectPos, GetAreaEnd(objectPos), true);
        gridMap.SetBuildableOfTiles(mouseCellPos, GetAreaEnd(mouseCellPos), false);
        GridMapDisplayer.Instance.SyncGridToTilemap();
    }
    private async UniTask MoveToPosition(Vector2Int cellPos)
    {
        Vector3 targetPos = gridMap
         .GetTile(cellPos.x, cellPos.y)
         .GetPositionOnTilemap(GridMapDisplayer.Instance.GetTilemap());

        await transform.DOMove(targetPos, 0.25f)
        .ToUniTask()
        .AttachExternalCancellation(destroyCancellationToken);
    }
    private bool CanMoveToPosition(Vector2Int targetPos)
    {
        Vector2Int objectPos = GetCellPositionOfGameObject();
        bool canMoveWithoutDelete = gridMap.CanTakeArea(targetPos, GetAreaEnd(targetPos));
        gridMap.SetBuildableOfTiles(objectPos, GetAreaEnd(objectPos), true);
        bool canMoveWithDelete = gridMap.CanTakeArea(targetPos, GetAreaEnd(targetPos));
        gridMap.SetBuildableOfTiles(objectPos, GetAreaEnd(objectPos), false);
        return canMoveWithDelete || canMoveWithoutDelete;
    }

    private Vector2Int GetCellPositionOfGameObject()
    {
        Vector2 pos = transform.position;
        return new Vector2Int(tilemap.WorldToCell(pos).x, tilemap.WorldToCell(pos).y);
    }
    private void Place()
    {
        placed = true;
        SaveManager.Instance.Save().Forget();
    }
    private void Remove()
    {
        Vector2Int objectPos = GetCellPositionOfGameObject();
        gridMap.SetBuildableOfTiles(objectPos, GetAreaEnd(objectPos), true);
        GridMapDisplayer.Instance.SyncGridToTilemap();
        Destroy(gameObject);
        SaveManager.Instance.Save().Forget();
    }
}
public static class TilemapExtensions
{
    public static Vector2Int GetCellPositionOfMouse(this Tilemap tilemap)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2Int(tilemap.WorldToCell(mousePos).x, tilemap.WorldToCell(mousePos).y);
    }
}