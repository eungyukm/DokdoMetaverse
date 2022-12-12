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

    [Tooltip("UI 작업용 테스트 모드입니다. 체크시 아이템 및 슬롯 동적 생성을 비활성화 합니다.")]
    [SerializeField] private bool testMode = false;

    private void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// 초기화
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
    /// 아이템 상태 리셋. 에디터 디버그 용도.
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
    /// 슬롯 추가
    /// </summary>
    public void AddSlot()
    {
        Transform slot = Instantiate(slotPrefab, content).transform;

        slot.GetComponent<InventorySlot>().index = slotList.Count;

        slotList.Add(slot);
    }

    /// <summary>
    /// 슬롯 삭제
    /// </summary>
    public void RemoveSlot(int slotIndex)
    {
        InventoryItem item = slotList[slotIndex].GetComponent<InventorySlot>().item;

        // 아이템 삭제
        itemDictionary.Remove(item.itemSO.itemName);
        Destroy(item);

        // 슬롯 삭제
        slotList.Remove(slotList[slotIndex].transform);
        Destroy(slotList[slotIndex]);
    }

    /// <summary>
    /// 슬롯 재활용. 
    /// </summary>
    public void RecycleSlot(int slotIndex)
    {
        InventorySlot slot = slotList[slotIndex].GetComponent<InventorySlot>();

        if (!slot.Empty()) return;
        else slotList[slotIndex].SetAsLastSibling();
    }

    /// <summary>
    /// 아이템 추가
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
    /// 아이템 소유 유무 세팅
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="check"></param>
    public void SetItemEarned(string itemName, bool check)
    {
        itemDictionary[itemName].SetItemEarned(check);
        SetItemCount();
    }

    /// <summary>
    /// 아이템 새로 획득했는지 유무 세팅
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="check"></param>
    public void SetItemNewChecked(string itemName, bool check)
    {
        itemDictionary[itemName].SetItemNewChecked(check);
    }

    /// <summary>
    /// 아이템 삭제
    /// </summary>
    /// <param name="itemName">삭제할 아이템 이름</param>
    public void RemoveItem(string itemName)
    {
        InventoryItem item = itemDictionary[itemName];
        InventorySlot slot = item.transform.parent.GetComponent<InventorySlot>();

        itemDictionary.Remove(itemName);
        slot.item = null;
        Destroy(item);

        RecycleSlot(slot.index); // 슬롯 추가
    }

    /// <summary>
    /// 수동으로 슬롯 선택. 처음 초기화시 특정 아이템을 선택한 상태가 되도록 하기 위함.
    /// </summary>
    /// <param name="slotIndex"></param>
    private void SelectSlot(int slotIndex)
    {
        var currentItem = slotList[slotIndex].GetComponent<InventorySlot>().item.GetComponent<Button>();
        currentItem.Select();
        currentItem.onClick.Invoke();
    }
}
