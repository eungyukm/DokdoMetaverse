using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class InventoryItem : MonoBehaviour
{
    public ItemSO itemSO;

    private Button button;
    [Header("Item Element Image")]
    [SerializeField] private Image itemImage;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private Sprite hiddenItemSprite;

    [SerializeField] private Transform newIcon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;

    [Header("Button Element Image")]
    [SerializeField] private Image targetGraphic;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite selectedSprite; 

#if UNITY_EDITOR
    private void OnValidate()
    {
        if(!button) button = GetComponent<Button>();

        button.transition = Selectable.Transition.SpriteSwap;

        if (itemSO)
        {
            if (itemSO.earned)
            {
                if (itemImage) itemImage.sprite = itemSO.itemIcon;
            }
            else
            {
                if (itemImage) itemImage.sprite = itemSO.hiddenItemIcon;
            }
        }
        

        if (targetGraphic)
        {
            targetGraphic.sprite = defaultSprite;

            button.targetGraphic = targetGraphic;

            SpriteState _spriteState = new SpriteState();
            _spriteState.selectedSprite = selectedSprite;

            button.spriteState = _spriteState;
        }
    }
#endif

    private void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// �ʱ�ȭ
    /// </summary>
    private void Initialize()
    {
        button = GetComponent<Button>();
        button.transition = Selectable.Transition.SpriteSwap;
    }

    /// <summary>
    /// �� Ŭ������ ���� �ִ� ������ ��ũ���ͺ� ������Ʈ�� ������� ������ ǥ�� ����
    /// </summary>
    public void SetItemElement()
    {
        if (itemSO.itemIcon != null) SetImageAlpha(itemImage, 1);
        else SetImageAlpha(itemImage, 0);

        this.gameObject.name = "Item_" + itemSO.itemName;

        SetShowItem();
        SetItemNewChecked(itemSO.isNew);        
    }

    /// <summary>
    /// �������� ȹ���ߴ��� �ƴ��� ǥ��
    /// </summary>
    /// <param name="check"></param>
    public void SetItemEarned(bool check)
    {
        itemSO.catchCount++;

        if (itemSO.earned) return;

        itemSO.earned = check;
        SetItemNewChecked(check);

        SetShowItem();
    }

    /// <summary>
    /// �������� ���� ���� ������ �ƴ��� ǥ��
    /// </summary>
    /// <param name="check"></param>
    public void SetItemNewChecked(bool check)
    {
        itemSO.isNew = check;
        if(newIcon) newIcon.gameObject.SetActive(check);
    }

    /// <summary>
    /// �̹��� ���İ� ����
    /// </summary>
    /// <param name="image"></param>
    /// <param name="alpha"></param>
    private void SetImageAlpha(Image image, int alpha)
    {
        Color temp = image.color;
        temp.a = alpha;
        image.color = temp;
    }

    /// <summary>
    /// �������� ȹ�� ������ ������ ǥ�� ����
    /// </summary>
    private void SetShowItem()
    {
        if (itemSO.earned)
        {
            if (itemImage) itemImage.sprite = itemSO.itemIcon;
            if (nameText) nameText.text = itemSO.itemName;
            if (descriptionText) descriptionText.text = itemSO.description;
        }
        else
        {
            if (itemImage) itemImage.sprite = itemSO.hiddenItemIcon;
            if (nameText) nameText.text = "?????";
            if (descriptionText) descriptionText.text = "????????";
        }
    }
}
