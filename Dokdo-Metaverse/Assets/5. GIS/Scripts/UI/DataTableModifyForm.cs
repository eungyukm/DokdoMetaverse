using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DataTableModifyForm : MonoBehaviour
{
    public int index = -1;
    public TMP_Text pnuText;
    public TMP_InputField sidoCDField;
    public TMP_InputField sidoNMField;
    public TMP_InputField sgg_CDField;
    public TMP_InputField sgg_nmField;
    public TMP_InputField emdCDField;
    public TMP_InputField emdNMField;
    public TMP_InputField riCDField;
    public TMP_InputField riNMField;
    public Button ComformButton;

    public UnityAction<MapItem, int> OnComformClick;

    private void Start()
    {
        ComformButton.onClick.AddListener(ConformClicked);
    }


    public void InitField(MapItem mapItem, int index)
    {
        this.index = index;
        pnuText.text = mapItem.PNU;
        sidoCDField.text = mapItem.SID0_CD;
        sidoNMField.text = mapItem.SID0_NM;
        sgg_CDField.text = mapItem.SGG_CD;
        sgg_nmField.text = mapItem.SGG_NM;
        emdCDField.text = mapItem.EMD_CD;
        emdNMField.text = mapItem.EMD_NM;
        riCDField.text = mapItem.RI_CD;
        riNMField.text = mapItem.RI_NM;
    }

    private void ConformClicked()
    {
        MapItem mapItem = new MapItem();
        mapItem.PNU = pnuText.text;
        mapItem.SID0_CD = sidoCDField.text;
        mapItem.SID0_NM = sidoNMField.text;
        mapItem.SGG_CD = sgg_CDField.text;
        mapItem.SGG_NM = sgg_nmField.text;
        mapItem.EMD_CD = emdCDField.text;
        mapItem.EMD_NM = emdNMField.text;
        mapItem.RI_CD = riCDField.text;
        mapItem.RI_NM = riNMField.text;
        
        OnComformClick?.Invoke(mapItem, index);
    }
}
