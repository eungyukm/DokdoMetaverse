using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemGroupSO")]
public class ItemGroupSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();

    /// <summary>
    /// 아이템 상태 리셋. 에디터 디버그 용도.
    /// </summary>
    public void ResetItemsStatus()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].ResetStatusValue();
        }
    }
}
