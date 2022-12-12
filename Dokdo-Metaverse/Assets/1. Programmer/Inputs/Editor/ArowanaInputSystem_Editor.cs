using UnityEditor;

[CustomEditor(typeof(ArowanaInputSystem))]
public class ArowanaInputSystem_Editor : Editor
{
    ArowanaInputSystem inputSystem;

    private void OnEnable()
    {
        inputSystem = (ArowanaInputSystem)target;
    }
}
