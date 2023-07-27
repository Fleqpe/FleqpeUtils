using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "ScriptableObject/Item Database")]
public class PlayerItemDatabase : ScriptableObject
{
      public List<PlayerItemData> ItemDatas = new List<PlayerItemData>();
      private static PlayerItemDatabase GetDatabase(ItemType type)
      {
            return Resources.Load<PlayerItemDatabase>(type.ToString() + "Database");
      }
      public static PlayerItemData GetPlayerItemData(ItemType type, string id)
      {
            return GetDatabase(type).ItemDatas.Find(x => x.id == id);
      }

}
