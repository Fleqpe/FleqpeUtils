using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDatabase", menuName = "ScriptableObject/Building Database")]
public class BuildingDatabase : ScriptableObject
{
      public List<BuildingObject> buildingObjects = new List<BuildingObject>();
      private static BuildingDatabase GetBuildingDatabase()
      {
            return Resources.Load<BuildingDatabase>("BuildingDatabase");
      }
      public static BuildingObject GetBuildingObject(string id)
      {
            return GetBuildingDatabase().buildingObjects.Find(x => x.id == id);
      }
      public static BuildingObject GetBuildingObject(GameObject gameObject)
      {
            return GetBuildingDatabase().buildingObjects.Find(x => x.obj == gameObject);
      }
}
