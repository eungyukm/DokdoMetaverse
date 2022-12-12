using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

[RequireComponent(typeof(ScrollRect))]
public class Inventory : MonoBehaviour
{
    public ItemGroupSO itemGroupSO;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject slotPrefab;

    //[SerializeField] private GridLayoutGroup itemLayoutGroup;
    //[SerializeField] private Vector2 slotSize = new Vector2(100f, 100f);

    [SerializeField] private bool useChecklistToggle = true;

    [SerializeField] private Transform content;

    [SerializeField] private TMP_Text itemCount;

    [Range(1, 200)]
    public int slotCount = 25;

    public List<Transform> slotList;
    public Dictionary<string, InventoryItem> itemDictionary;

    [Tooltip("UI �۾��� �׽�Ʈ ����Դϴ�. üũ�� ������ �� ���� ���� ������ ��Ȱ��ȭ �մϴ�.")]
    [SerializeField] private bool testMode = false;

    private void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// �ʱ�ȭ
    /// </summary>
    private void Initialize()
    {
        if (testMode) return;

        //if (!itemLayoutGroup) GetComponentInChildren<GridLayoutGroup>();
        //itemLayoutGroup.cellSize = slotSize;
        //RectTransform itemPrefabRect = itemPrefab.GetComponent<RectTransform>();
        //itemPrefabRect.localScale = slotSize / itemPrefabRect.sizeDelta;

        itemDictionary = new Dictionary<string, InventoryItem>();

        for (int i = 0; i < itemGroupSO.items.Count; i++)
        {
            AddSlot();
            AddItem(i);
        }

        if (slotCount > itemGroupSO.items.Count)
        {
            for (int i = 0; i < slotCount - itemGroupSO.items.Count; i++)
            {
                AddSlot();
            }
        }

        SetItemCount();

        //SelectSlot(0);
    }

    /// <summary>
    /// ������ ���� ����. ������ ����� �뵵.
    /// </summary>
    public void ResetItemsStatus()
    {
        for (int i = 0; i < itemGroupSO.items.Count; i++)
        {
            itemGroupSO.items[i].ResetStatusValue();
        }
    }

    public void SetItemCount()
    {
        int earnedCount = 0;

        for (int i = 0; i < itemGroupSO.items.Count; i++)
        {
            if (itemGroupSO.items[i].earned) earnedCount++;
        }

        itemCount.text = $"{earnedCount} / {itemGroupSO.items.Count}";
    }

    /// <summary>
    /// ���� �߰�
    /// </summary>
    public void AddSlot()
    {
        Transform slot = Instantiate(slotPrefab, content).transform;

        slot.GetComponent<InventorySlot>().index = slotList.Count;

        slotList.Add(slot);
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void RemoveSlot(int slotIndex)
    {
        InventoryItem item = slotList[slotIndex].GetComponent<InventorySlot>().item;

        // ������ ����
        itemDictionary.Remove(item.itemSO.itemName);
        Destroy(item);

        // ���� ����
        slotList.Remove(slotList[slotIndex].transform);
        Destroy(slotList[slotIndex]);
    }

    /// <summary>
    /// ���� ��Ȱ��. 
    /// </summary>
    public void RecycleSlot(int slotIndex)
    {
        InventorySlot slot = slotList[slotIndex].GetComponent<InventorySlot>();

        if (!slot.Empty()) return;
        else slotList[slotIndex].SetAsLastSibling();
    }

    /// <summary>
    /// ������ �߰�
    /// </summary>
    public void AddItem(int slotIndex)
    {
        GameObject itemGO = Instantiate(itemPrefab, slotList[slotIndex]);

        InventorySlot _slot = slotList[slotIndex].GetComponent<InventorySlot>();
        InventoryItem _item = itemGO.GetComponent<InventoryItem>();
        Button _button = itemGO.GetComponent<Button>();

        _slot.item = _item;
        _item.itemSO = itemGroupSO.items[slotIndex];
        _item.SetItemElement();

        itemDictionary.Add(_item.itemSO.itemName, _item);
    }

    /// <summary>
    /// ������ ���� ���� ����
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="check"></param>
    public void SetItemEarned(string itemName, bool check)
    {
        itemDictionary[itemName].SetItemEarned(check);
        SetItemCount();
    }

    /// <summary>
    /// ������ ���� ȹ���ߴ��� ���� ����
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="check"></param>
    public void SetItemNewChecked(string itemName, bool check)
    {
        itemDictionary[itemName].SetItemNewChecked(check);
    }

    /// <summary>
    /// ������ ����
    /// </summary>
    /// <param name="itemName">������ ������ �̸�</param>
    public void RemoveItem(string itemName)
    {
        InventoryItem item = itemDictionary[itemName];
        InventorySlot slot = item.transform.parent.GetComponent<InventorySlot>();

        itemDictionary.Remove(itemName);
        slot.item = null;
        Destroy(item);

        RecycleSlot(slot.index); // ���� �߰�
    }

    /// <summary>
    /// �������� ���� ����. ó�� �ʱ�ȭ�� Ư�� �������� ������ ���°� �ǵ��� �ϱ� ����.
    /// </summary>
    /// <param name="slotIndex"></param>
    private void SelectSlot(int slotIndex)
    {
        var currentItem = slotList[slotIndex].GetComponent<InventorySlot>().item.GetComponent<Button>();
        currentItem.Select();
        currentItem.onClick.Invoke();
    }
}
