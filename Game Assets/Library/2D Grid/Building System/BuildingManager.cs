using UnityEngine;
[DefaultExecutionOrder(10)]
public class BuildingManager : MonoBehaviour
{
    void Awake()
    {
        LoadBuildings();
    }
    #region Data Management
    private void LoadBuildings()
    {
        PlaceableItemDatabase placeableItemDatabase = PlaceableItemDatabase.Instance;
        foreach (PlaceableObjectSaveData data in SaveManager.gameFiles.roomSaveData.placeableObjects)
        {
            Vector3 localPos = BuildingSystem.instance.gridLayout.CellToLocalInterpolated(data.pos);
            GameObject building = Instantiate(placeableItemDatabase.itemDatas[data.ID].prefab, localPos, Quaternion.identity, BuildingSystem.instance.buildingsParent);
            PlaceableObjectDataHandler dataHandler = building.GetComponent<PlaceableObjectDataHandler>();
            PlaceableObject placeableObject = building.GetComponent<PlaceableObject>();
            if (placeableItemDatabase.itemDatas.Exists(x => x.ID == data.ID))
                dataHandler.LoadData(data, placeableObject);
            else
                Destroy(building);
        }
    }
    #endregion
}
