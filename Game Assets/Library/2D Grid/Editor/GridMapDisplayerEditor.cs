using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridMapDisplayer))]
public class GridMapDisplayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GridMapDisplayer displayer = (GridMapDisplayer)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Sync Tilemap To Grid"))
            displayer.SyncTilemapToGrid();
        if (GUILayout.Button("Sync Grid To Tilemap"))
            displayer.SyncTilemapToGrid();
        if (GUILayout.Button("Delete Map"))
            displayer.DeleteMap();
        if (GUI.changed)
            EditorUtility.SetDirty(displayer);
    }
}
