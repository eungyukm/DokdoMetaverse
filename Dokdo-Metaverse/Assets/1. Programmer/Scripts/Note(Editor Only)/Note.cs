#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

/// <summary>
/// 인스펙터 창에 메모할 일이 있을 때 사용.
/// 
/// 작성자: 변고경
/// 작성일자: 2021/7/22
/// </summary>
[ExecuteInEditMode]
public class Note : MonoBehaviour
{
#if UNITY_EDITOR
    [HideInInspector]
    public string text;

    [HideInInspector]
    public bool locked;

    [Tooltip("test")]
    [HideInInspector]
    public int fontSize = 12;

    [HideInInspector]
    public int typingAreaHeight = 10;
#endif
}
#if UNITY_EDITOR
[ExecuteInEditMode]
[CustomEditor(typeof(Note))]
#endif
#if UNITY_EDITOR
public class Note_Editor : Editor
{

    private Note note;

    private Vector2 scroll;

    private void OnEnable()
    {
        note = (Note)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        note.fontSize = EditorGUILayout.IntField("Font Size", note.fontSize);

        if (note.locked)
        {
            EditorGUILayout.HelpBox(note.text, MessageType.None);
            EditorStyles.helpBox.richText = true;
            EditorStyles.helpBox.fontSize = note.fontSize;

            if (GUILayout.Button("Edit"))
            {
                note.locked = false;
            }
        }
        else
        {
            EditorUtility.SetDirty(note);

            note.typingAreaHeight = EditorGUILayout.IntSlider("Typing Area Height", note.typingAreaHeight, 1, 100);

            if (note.typingAreaHeight < 0) note.typingAreaHeight = 0;

            EditorGUILayout.PrefixLabel("Typing Area");
            scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.MaxHeight(note.typingAreaHeight * EditorGUIUtility.singleLineHeight));
            note.text = EditorGUILayout.TextArea(note.text, EditorStyles.textArea, GUILayout.MaxHeight(note.typingAreaHeight * EditorGUIUtility.singleLineHeight));
            EditorStyles.textArea.fontSize = note.fontSize;
            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Save"))
            {
                note.locked = true;
                EditorUtility.ClearDirty(note);
            }
        }

        Undo.RecordObject(note, "");
    }

}
#endif
