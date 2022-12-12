using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem item;

    public int index = 0;

    public bool Empty()
    {
        return item == null;
    }
}
