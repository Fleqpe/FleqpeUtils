using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaceableItemDatabase", menuName = "ScriptableObjects/PlaceableItem/Database)")]
public class PlaceableItemDatabase : SingletonSO<PlaceableItemDatabase>
{
    public List<PlaceableItemData> itemDatas = new List<PlaceableItemData>();
}
