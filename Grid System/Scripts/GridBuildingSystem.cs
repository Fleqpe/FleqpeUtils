using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;
using DG.Tweening;
public class GridBuildingSystem : MonoBehaviour
{
      public Vector3Int mouseToCellPos { get { return tempTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)); } }
      public Vector3 mouseToWorlPos { get { return tempTilemap.CellToWorld(mouseToCellPos); } }
      public GridRaycaster gridRaycaster;
      public Tilemap tempTilemap;
      public TileBase notBuildable, buildable, empty;
      public GameObject selectedPrefab;
      public Building tempBuilding;
      private void Start()
      {
            InvokeRepeating("BuildingLogic", 0f, 0.2f);
      }
      private void Update()
      {
            if (Input.GetMouseButtonDown(0) && selectedPrefab != null && GetTile(mouseToCellPos) != null)
                  PlaceBuilding();
      }
      public bool IsAreaSafeToFollow()
      {
            BoundsInt areaToCheck = new BoundsInt();
            areaToCheck.position = mouseToCellPos;
            areaToCheck.size = selectedPrefab.GetComponent<Building>().area.size;
            foreach (Vector3Int point in areaToCheck.allPositionsWithin)
            {
                  //This one checks out of bounds.
                  if (GetTile(point) == null)
                        return false;
                  //this one checks if its colliding with something.
                  else if (GetTile(point) == notBuildable)
                        return false;
            }
            return true;
      }
      public void FollowBuilding()
      {
            SetArea(tempBuilding.area, empty);
            tempBuilding.spriteRenderer.color = Color.green;
            tempBuilding.transform.DOMove(mouseToWorlPos, 0.5f);
            tempBuilding.area.position = mouseToCellPos;
            SetArea(tempBuilding.area, buildable);
      }
      public void PlaceBuilding()
      {
            SetBuildingData();
            tempTilemap.gameObject.SetActive(false);
            tempBuilding.Toggle();
            tempBuilding.spriteRenderer.color = Color.white;
            SetArea(tempBuilding.area, notBuildable);
            tempBuilding = null;
            selectedPrefab = null;
            SaveManager.Save();
      }
      public void SetBuildingData()
      {
            if (tempBuilding.buildingData == null)
            {
                  BuildingData data = new BuildingData(BuildingDatabase.GetBuildingObject(selectedPrefab).id, mouseToCellPos, 1);
                  SaveManager.gameFiles.buildingDatas.Add(data);
                  tempBuilding.buildingData = data;
            }
            else
            {
                  tempBuilding.buildingData.pos = mouseToCellPos;
            }
      }
      public void InitiliazeBuilding()
      {
            tempBuilding = Instantiate(selectedPrefab, mouseToWorlPos, Quaternion.identity).GetComponent<Building>();
            tempBuilding.area.position = mouseToCellPos;
            FollowBuilding();
      }
      public void BuildingLogic()
      {
            if (selectedPrefab == null || GetTile(mouseToCellPos) == null)
                  return;

            if (IsAreaSafeToFollow())
            {
                  if (tempBuilding == null)
                        InitiliazeBuilding();
                  else if (tempBuilding.area.position != mouseToCellPos)
                        FollowBuilding();
            }
      }
      public void SetArea(BoundsInt bounds, TileBase tile)
      {
            foreach (Vector3Int point in bounds.allPositionsWithin)
                  tempTilemap.SetTile(point, tile);
      }
      public TileBase GetTile(Vector3Int pos)
      {
            return tempTilemap.GetTile(pos);
      }
      public void SelectPrefab(GameObject prefab)
      {
            tempTilemap.gameObject.SetActive(true);
            selectedPrefab = prefab;
      }
      public void MoveBuilding()
      {
            tempBuilding = gridRaycaster.building;
            selectedPrefab = gridRaycaster.building.gameObject;
            gridRaycaster.SetBuilding(null);
            SetArea(tempBuilding.area, empty);
            tempBuilding.Toggle();
            tempTilemap.gameObject.SetActive(true);
      }
      public void DestroyBuilding()
      {
            SaveManager.gameFiles.buildingDatas.Remove(gridRaycaster.building.buildingData);
            SetArea(gridRaycaster.building.area, empty);
            Destroy(gridRaycaster.building.gameObject);
            gridRaycaster.SetBuilding(null);
            SaveManager.Save();
      }
}