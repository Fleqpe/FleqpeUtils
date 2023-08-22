
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(MultiImageButton))]
public class MultiImageButtonEditor : Editor
{
    private SerializedProperty _property;
    private ReorderableList _list;
    private void OnEnable()
    {
        _property = serializedObject.FindProperty("targetGraphics");
        _list = new ReorderableList(serializedObject, _property, true, true, true, true)
        {
            drawHeaderCallback = DrawListHeader,
            drawElementCallback = DrawListElement
        };
    }
    private void DrawListHeader(Rect rect)
    {
        GUI.Label(rect, "Target Graphics");
    }
    private void DrawListElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        var item = _property.GetArrayElementAtIndex(index);
        EditorGUI.PropertyField(rect, item);
    }
    public override void OnInspectorGUI()
    {
        SerializedObject button = new SerializedObject(target);
        button.Update();
        _list.DoLayoutList();
        SerializedProperty interactable = button.FindProperty("m_Interactable");
        SerializedProperty onClick = button.FindProperty("m_OnClick");
        SerializedProperty colors = button.FindProperty("m_Colors");
        EditorGUILayout.PropertyField(interactable, true);
        EditorGUILayout.PropertyField(colors, true);
        EditorGUILayout.PropertyField(onClick, true);
        button.ApplyModifiedProperties();
    }
}