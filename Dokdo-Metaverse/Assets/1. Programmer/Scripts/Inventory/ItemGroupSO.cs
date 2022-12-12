using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemGroupSO")]
public class ItemGroupSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();

    /// <summary>
    /// ������ ���� ����. ������ ����� �뵵.
    /// </summary>
    public void ResetItemsStatus()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].ResetStatusValue();
        }
    }
}
