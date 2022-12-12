using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemGroupSO))]
public class ItemGroupSO_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemGroupSO itemGroup = (ItemGroupSO)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Reset All Item SO Status"))
        {
            itemGroup.ResetItemsStatus();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
