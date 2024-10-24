using FleqpeUtils.BreakInfinity;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaceableObjectEntry", menuName = "ScriptableObjects/PlaceableObject/Entry")]
public class PlaceableObjectEntry : ScriptableObject
{
    public string itemName, description;
    public int ID, maxCount;
    public GameObject prefab;
    public Sprite icon;
    public BigDouble buyPrice, sellPrice;
    public bool canSold;
}
