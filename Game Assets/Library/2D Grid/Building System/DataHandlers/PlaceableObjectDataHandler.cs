using System.Collections.Generic;
using UnityEngine;

public abstract class PlaceableObjectDataHandler : MonoBehaviour
{
    [SerializeField] protected PlaceableItemData placeableItemData;
    protected PlaceableObjectSaveData data;
    public abstract void SetSaveData(PlaceableObject placeableObject);
    public PlaceableObjectSaveData GetSaveData()
    {
        return data;
    }
    public void Remove()
    {
        if (data != null && SaveManager.gameFiles.roomSaveData.placeableObjects.Exists(x => x == data))
            SaveManager.gameFiles.roomSaveData.placeableObjects.Remove(data);
    }
    public void SetDataPosition(Vector3Int cellPos)
    {
        data.pos = cellPos;
    }
    public void LoadData(PlaceableObjectSaveData data, PlaceableObject placeableObject)
    {
        this.data = data;
        placeableObject.placed = true;
        transform.position = data.pos + placeableObject.offset;
        placeableObject.area.position = data.pos;
        BuildingSystem.instance.TakeArea(placeableObject.area, placeableObject.canWalkThrough);
    }
}