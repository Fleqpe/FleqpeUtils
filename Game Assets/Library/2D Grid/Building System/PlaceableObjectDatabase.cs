using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaceableObjectDatabase", menuName = "ScriptableObjects/PlaceableObject/Database)")]
public class PlaceableObjectDatabase : SingletonSO<PlaceableObjectDatabase>
{
    public List<PlaceableObjectEntry> placeableObjectEntries = new List<PlaceableObjectEntry>();
}
