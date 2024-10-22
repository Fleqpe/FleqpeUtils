using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pathfinding
{
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 999;
    private List<PathNode> openList = new List<PathNode>();
    private List<PathNode> closedList = new List<PathNode>();
    private List<PathNode> simulationArea = new List<PathNode>();
    public Tilemap walkInfoTileMap => BuildingSystem.instance.walkInfoTilemap;
    public TileBase walkable => BuildingSystem.instance.walkableTile;
    public List<PathNode> FindPath(Vector3Int start, Vector3Int end, bool canMoveAllTiles)
    {
        return FindPath(start.x, start.y, end.x, end.y, canMoveAllTiles);
    }
    public List<PathNode> FindPath(int startX, int startY, int endX, int endY, bool canMoveAllTiles)
    {
        ResetPathfinding(canMoveAllTiles);
        PathNode endNode = simulationArea.FirstOrDefault(node => node.x == endX && node.y == endY);
        PathNode startNode = simulationArea.FirstOrDefault(node => node.x == startX && node.y == startY);
        if (startNode == null || endNode == null)
            return null;
        openList.Add(startNode);
        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);

        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode.x == endNode.x && currentNode.y == endNode.y)
                return CalculatePath(endNode);
            openList.Remove(currentNode);
            closedList.Add(currentNode);
            foreach (PathNode neighbourNode in GetNeighbourNodes(currentNode))
            {
                if (closedList.Contains(neighbourNode))
                    continue;
                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.previousNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    if (!openList.Contains(neighbourNode))
                        openList.Add(neighbourNode);
                }
            }
        }
        return null;
    }
    private void ResetPathfinding(bool canMoveAllTiles)
    {
        simulationArea.Clear();
        openList.Clear();
        closedList.Clear();
        if (!canMoveAllTiles)
        {
            foreach (Vector3Int pos in walkInfoTileMap.cellBounds.allPositionsWithin)
                if (walkInfoTileMap.GetTile(pos) == walkable)
                    simulationArea.Add(new PathNode(pos.x, pos.y) { gCost = int.MaxValue, previousNode = null });
        }
        else
        {
            foreach (Vector3Int pos in walkInfoTileMap.cellBounds.allPositionsWithin)
                if (walkInfoTileMap.GetTile(pos) != null)
                    simulationArea.Add(new PathNode(pos.x, pos.y) { gCost = int.MaxValue, previousNode = null });
        }
    }
    private List<PathNode> GetNeighbourNodes(PathNode currentNode)
    {
        List<PathNode> pathNodes = new List<PathNode>();
        int[] directions = { -1, 0, 1 };

        foreach (int dx in directions)
            foreach (int dy in directions)
            {
                if ((dx == 0 && dy == 0) || (dx != 0 && dy != 0)) continue;
                PathNode neighborNode = simulationArea.FirstOrDefault(node => node.x == currentNode.x + dx && node.y == currentNode.y + dy);
                if (neighborNode != null)
                    pathNodes.Add(neighborNode);
            }
        return pathNodes;
    }
    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>() { endNode };
        PathNode currentNode = endNode;
        while (currentNode.previousNode != null)
        {
            path.Add(currentNode.previousNode);
            currentNode = currentNode.previousNode;
        }
        path.Reverse();
        return path;
    }
    private int CalculateDistanceCost(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }
    private PathNode GetLowestFCostNode(List<PathNode> pathNodes) => pathNodes.OrderBy(x => x.fCost).First();
}
[System.Serializable]
public class PathNode
{
    public int x;
    public int y;
    public int gCost;
    public int hCost;
    public int fCost => gCost + hCost;
    public Vector3Int pos => new Vector3Int(x, y, 0);
    public PathNode previousNode;
    public PathNode(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return x + "," + y;
    }
}