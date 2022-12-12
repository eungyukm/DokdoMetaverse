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
    /// 초기화
    /// </summary>
    private void Initialize()
    {
        button = GetComponent<Button>();
        button.transition = Selectable.Transition.SpriteSwap;
    }

    /// <summary>
    /// 본 클래스가 갖고 있는 아이템 스크립터블 오브젝트를 기반으로 아이템 표시 세팅
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
    /// 아이템을 획득했는지 아닌지 표시
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
    /// 아이템이 새로 얻은 것인지 아닌지 표시
    /// </summary>
    /// <param name="check"></param>
    public void SetItemNewChecked(bool check)
    {
        itemSO.isNew = check;
        if(newIcon) newIcon.gameObject.SetActive(check);
    }

    /// <summary>
    /// 이미지 알파값 조정
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
    /// 아이템의 획득 유무로 아이템 표시 세팅
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
