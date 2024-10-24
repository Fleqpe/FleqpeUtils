using UnityEngine;
public class PathfindingTester : MonoBehaviour
{
    public Vector2Int start = Vector2Int.zero, end = Vector2Int.zero;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            end = GridMapDisplayer.Instance.GetTilemap().GetCellPositionOfMouse();
        }
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            start = GridMapDisplayer.Instance.GetTilemap().GetCellPositionOfMouse();
        }
        if (start != Vector2Int.zero && end != Vector2Int.zero)
        {
            new Pathfinding().FindPath(start.x, start.y, end.x, end.y, true)?.ForEach(x => Debug.Log(x.ToString()));
            start = Vector2Int.zero;
            end = Vector2Int.zero;
        }
    }
}
