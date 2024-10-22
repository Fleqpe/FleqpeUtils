using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlaceableObject : MonoBehaviour
{
    public Vector3 offset, interactOffset;
    public BoundsInt area;
    public Vector3 GetInteractPoint => area.position + interactOffset;
    public bool canReplace = true, canNPCInteract = false, placed, canWalkThrough;
    [SerializeField] private PlaceableObjectDataHandler placeableObjectDataHandler;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D cl2d;
    [SerializeField] private CanvasGroup replaceItemMenu;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button replaceButton, removeButton;
    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private BoundsInt tempArea;
    private void Awake()
    {
        canvas.worldCamera = Camera.main;
        replaceButton.onClick.AddListener(Replace);
        removeButton.onClick.AddListener(Remove);
    }
    private void OnEnable()
    {
        BuildingSystem.onPlaceCancel += OnPlaceCancelCallBack;
    }
    private void OnDisable()
    {
        BuildingSystem.onPlaceCancel -= OnPlaceCancelCallBack;
    }
    private void Start()
    {
        Movement(cancellationTokenSource.Token)
        .Forget();
    }
    private void Update()
    {
        cl2d.enabled = placed;
    }
    private void LateUpdate()
    {
        if (!placed && Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            Place();
    }
    private void OnMouseDown()
    {
        if (canReplace)
            replaceItemMenu.Switch();
    }
    private void OnDestroy()
    {
        cancellationTokenSource?.Cancel();
        cancellationTokenSource?.Dispose();
    }
    #region PlaceableObject Specific Methods
    private async UniTaskVoid Movement(CancellationToken token)
    {
        try
        {
            await UniTask.WaitUntil(() => !placed && transform.position != GetLocalPosOfMouse() + offset, cancellationToken: token);
            ClearTemporaryArea();
            UniTask moveTask = transform.DOMove(GetLocalPosOfMouse() + offset, 0.1f)
            .ToUniTask(cancellationToken: token);
            bool canTakeArea = BuildingSystem.instance.CanTakeArea(GetAreaOfMouse());
            spriteRenderer.color = (canTakeArea ? Color.green : Color.red) - new Color(0, 0, 0, 0.6f);
            SetTemporaryArea(canTakeArea);
            await UniTask.WhenAny(moveTask);
            Movement(token).Forget();
        }
        catch (OperationCanceledException)
        {
            Debug.Log("Stopped Movement");
        }
    }
    private void SetAreaPositionToCurrentCellPosOfMouse()
    {
        Vector3Int cellPos = BuildingSystem.instance.gridLayout.LocalToCell(GetLocalPosOfMouse());
        area.position = cellPos;
    }
    private Vector3Int GetCellPosOfMouse()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = BuildingSystem.instance.gridLayout.WorldToCell(pos);
        return cellPos;
    }
    private Vector3 GetLocalPosOfMouse()
    {
        Vector3 cellPos = GetCellPosOfMouse();
        Vector3 localPos = BuildingSystem.instance.gridLayout.CellToLocalInterpolated(cellPos);
        return localPos;
    }
    private BoundsInt GetAreaOfMouse()
    {
        BoundsInt areaToPlace = area;
        areaToPlace.position = GetCellPosOfMouse();
        return areaToPlace;
    }
    private void SetTemporaryArea(bool canTakeArea)
    {
        if (canTakeArea)
        {
            tempArea = GetAreaOfMouse();
            BuildingSystem.instance.TakeArea(tempArea, true);
        }
    }
    private void ClearTemporaryArea()
    {
        BuildingSystem.instance.ClearArea(tempArea, true);
        tempArea = new BoundsInt();
    }
    private void OnPlaceCancelCallBack()
    {
        if (!placed)
            Destroy(gameObject);
    }
    private void Place()
    {
        ClearTemporaryArea();
        if (BuildingSystem.instance.CanTakeArea(GetAreaOfMouse()))
        {
            placeableObjectDataHandler.SetSaveData(this);
            placeableObjectDataHandler.SetDataPosition(GetCellPosOfMouse());
            BuildingSystem.instance.TakeArea(GetAreaOfMouse(), canWalkThrough);
            placed = true;
            SetAreaPositionToCurrentCellPosOfMouse();
            spriteRenderer.color = Color.white;
            SaveManager.Instance.Save().Forget();
            BuildingSystem.onPlace?.Invoke();
        }
    }
    private void Replace()
    {
        BuildingSystem.instance.ClearArea(area, canWalkThrough);
        replaceItemMenu.Switch();
        UniTask.Void(async () =>
        {
            await UniTask.DelayFrame(1);
            placed = false;
            BuildingSystem.onReplace?.Invoke();
        });
    }
    private void Remove()
    {
        placeableObjectDataHandler.Remove();
        BuildingSystem.instance.ClearArea(area, canWalkThrough);
        ClearTemporaryArea();
        Destroy(gameObject);
        SaveManager.Instance.Save().Forget();
    }
    #endregion
}
