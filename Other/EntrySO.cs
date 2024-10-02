#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class EntrySO<T> : ScriptableObject where T : ScriptableObject
{
    [ReadOnly]
    public int ID;
    [Button("Set ID")]
    public void SetID()
    {
#if UNITY_EDITOR
        if (ID == 0)
        {
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");
            List<T> allObjects = guids.Select(guid => AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid))).ToList();
            T currentObject = this as T;
            string currentGuid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(currentObject));
            ID = currentGuid.GetHashCode();
            EditorUtility.SetDirty(this);
        }
#endif
    }
}