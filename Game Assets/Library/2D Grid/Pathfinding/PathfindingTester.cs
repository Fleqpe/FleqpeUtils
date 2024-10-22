using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathfindingTester : MonoBehaviour
{
    public Vector3Int start = Vector3Int.zero, end = Vector3Int.zero;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            end = BuildingSystem.instance.gridLayout.WorldToCell(pos);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            start = BuildingSystem.instance.gridLayout.WorldToCell(pos);
        }
        if (start != Vector3Int.zero && end != Vector3Int.zero)
        {
            new Pathfinding().FindPath(start.x, start.y, end.x, end.y, true)?.ForEach(x => Debug.Log(x.ToString()));
            start = Vector3Int.zero;
            end = Vector3Int.zero;
        }
    }
}
