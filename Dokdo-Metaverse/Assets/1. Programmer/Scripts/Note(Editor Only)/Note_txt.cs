#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[ExecuteInEditMode]
public class Note_txt : MonoBehaviour
{
#if UNITY_EDITOR
    public TextAsset textAsset;

    [HideInInspector]
    public string text = "";

    public int fontSize = 12;

    private void OnEnable()
    {
        text = textAsset.text;
    }
#endif
}
#if UNITY_EDITOR
[ExecuteInEditMode]
[CustomEditor(typeof(Note_txt))]
#endif
#if UNITY_EDITOR
public class Note_txt__Editor : Editor
{

    private Note_txt note;

    private bool a = true;

    private void OnEnable()
    {
        note = (Note_txt)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (note.textAsset != null) note.text = note.textAsset.text;
        EditorGUILayout.HelpBox(note.text, MessageType.None);
        EditorStyles.helpBox.richText = true;
        EditorStyles.helpBox.fontSize = note.fontSize;

    }
}
#endif
