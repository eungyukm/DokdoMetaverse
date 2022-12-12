using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MapItemSetter : MonoBehaviour
{
    public int idex = -1;
    public TMP_Text[] Texts;
    public Button selectBtn;
    public Button modifyBtn;

    public UnityAction<int, GameObject> OnSelectAction;
    public UnityAction<int> OnModifyAction;

    private Image _itemImage;


    private void Start()
    {
        _itemImage = GetComponent<Image>();
    }

    public void InitText(MapItem mapItem, int idex)
    {
        this.idex = idex;
        Texts[0].text = mapItem.PNU;
        Texts[1].text = mapItem.SID0_CD;
        Texts[2].text = mapItem.SID0_NM;
        Texts[3].text = mapItem.SGG_CD;
        Texts[4].text = mapItem.SGG_NM;
        Texts[5].text = mapItem.EMD_CD;
        Texts[6].text = mapItem.EMD_NM;
        Texts[7].text = mapItem.RI_CD;
        Texts[8].text = mapItem.RI_NM;

        selectBtn.onClick.AddListener(() =>
        {
            Debug.Log("index : " + idex);
            
            OnSelectAction?.Invoke(idex, gameObject);
        });
        
        modifyBtn.onClick.AddListener(() =>
        {
            Debug.Log("index : " + idex);
            OnModifyAction?.Invoke(idex);
        });
    }
}
