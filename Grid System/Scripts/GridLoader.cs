using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GridLoader : MonoBehaviour
{
      public GridBuildingSystem buildingSystem;
      public Tilemap tempTilemap;
      public void Start()
      {
            SaveManager.Load();
            LoadBuildings();
      }
      public void LoadBuildings()
      {
            foreach (BuildingData data in SaveManager.gameFiles.buildingDatas)
            {
                  GameObject createdObject = Instantiate(BuildingDatabase.GetBuildingObject(data.id).obj, tempTilemap.CellToWorld(data.pos), Quaternion.identity);
                  Building createdBuilding = createdObject.GetComponent<Building>();
                  createdBuilding.area.position = data.pos;
                  buildingSystem.SetArea(createdBuilding.area, buildingSystem.notBuildable);
                  createdBuilding.Toggle();
                  createdBuilding.buildingData = data;
            }
      }
}
