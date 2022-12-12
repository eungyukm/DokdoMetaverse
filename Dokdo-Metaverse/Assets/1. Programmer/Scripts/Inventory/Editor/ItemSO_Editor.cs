using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemSO))]
public class ItemSO_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawPropertiesExcluding(serializedObject, "description");

        
        EditorGUILayout.PrefixLabel("Description");
        ItemSO itemSO = (ItemSO)target;
        itemSO.description = EditorGUILayout.TextArea(itemSO.description, EditorStyles.textArea, GUILayout.MaxHeight(5 * EditorGUIUtility.singleLineHeight));

        if (GUILayout.Button("Reset Item SO Status"))
        {
            itemSO.ResetStatusValue();
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}
