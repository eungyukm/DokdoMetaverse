using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemSO")]
public class ItemSO : ScriptableObject
{
    public GameObject modelPrefab;

    public Sprite itemIcon;

    public Sprite hiddenItemIcon;

    public Sprite descriptionImage;

    public string itemName;

    public string description;

    public float maxLength;

    public float minLength;

    public bool earned = false;

    public bool isNew = false;

    [Range(0, 99)]
    public int catchCount = 0;

#if UNITY_EDITOR
    private void Awake()
    {
        if (UnityEditor.BuildPipeline.isBuildingPlayer)
        {
            ResetStatusValue();
        }
    }
#endif

    public void ResetStatusValue()
    {
        maxLength = 0;
        minLength = 0;
        earned = false;
        isNew = false;
        catchCount = 0;
    }
}
