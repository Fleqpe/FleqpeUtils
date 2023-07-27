using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BuildingData
{
      public string id;
      public Vector3Int pos;
      public int level;

      public BuildingData(string id, Vector3Int pos, int level)
      {
            this.id = id;
            this.pos = pos;
            this.level = level;
      }
}
