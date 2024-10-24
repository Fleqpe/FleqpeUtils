using UnityEngine;
public class PlaceableObjectDataLoader : SingletonManager<PlaceableObjectDataLoader>
{
    public Transform buildingsParent;
    void Awake()
    {
        LoadBuildings();
    }
    private void LoadBuildings()
    {
        foreach (PlaceableObjectData data in SaveManager.gameFiles.placeableObjectDatas)
            LoadBuilding(data);
    }
    private GameObject InstantiateBuilding(int ID, Vector3 pos)
    {
        GameObject prefab = PlaceableObjectDatabase.Instance.placeableObjectEntries[ID].prefab;
        return Instantiate(prefab, pos, Quaternion.identity, buildingsParent);
    }
    private void LoadBuilding(PlaceableObjectData data)
    {
        Vector3 localPos = GridMapDisplayer.Instance.GetTilemap().CellToLocalInterpolated(new Vector3(data.pos.x, data.pos.y));
        GameObject building = InstantiateBuilding(data.ID, localPos);
        PlaceableObject placeableObject = building.GetComponent<PlaceableObject>();
        placeableObject.Load(data.pos);
    }
}
