using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomSaveData
{
    public int roomID = 0;
    public List<PlaceableObjectSaveData> placeableObjects = new List<PlaceableObjectSaveData>();
}
