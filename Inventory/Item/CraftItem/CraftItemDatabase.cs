using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CraftItemDatabase", menuName = "ScriptableObject/Craft Item Database")]
public class CraftItemDatabase : ScriptableObject
{
      public List<CraftItemData> itemDatas = new List<CraftItemData>();
      private static CraftItemDatabase GetDatabase()
      {
            return Resources.Load<CraftItemDatabase>("CraftItemDatabase");
      }
      public static CraftItemData GetCraftItemData(string id)
      {
            return GetDatabase().itemDatas.Find(x => x.id == id);
      }
}
