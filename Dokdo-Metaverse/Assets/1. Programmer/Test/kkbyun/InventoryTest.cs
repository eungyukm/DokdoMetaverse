using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTest : MonoBehaviour
{
    public Button Button_Sewu;
    public Button Button_ALL;

    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        Button_Sewu.onClick.AddListener(() =>
        {
            inventory.SetItemEarned("독도 새우", true);
        });

        Button_ALL.onClick.AddListener(() =>
        {
            foreach (var item in inventory.itemGroupSO.items)
            {
                inventory.SetItemEarned(item.itemName, true);
            }
        });
    }
}
