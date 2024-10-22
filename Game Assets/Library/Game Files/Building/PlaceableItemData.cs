using FleqpeUtils.BreakInfinity;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/PlaceableItem/Item")]
public class PlaceableItemData : ScriptableObject
{

    public string itemName, description;
    public int ID, maxCount;
    public GameObject prefab;
    public Sprite icon;
    public BigDouble buyPrice, sellPrice;
    public bool canSold;
}
