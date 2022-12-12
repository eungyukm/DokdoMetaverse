using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DataTable : MonoBehaviour
{
    public DataTableTopMenu dataTableTopMenu;
    public GameObject dataTableRoot;
    public MapDataContents mapDataContents;

    public UnityAction OnCloseDataTable;

    private void OnEnable()
    {
        dataTableTopMenu.OnCloseButtonClick += ClosePanel;

        mapDataContents.OnMapDataSelected += MapDataSelected;
    }

    private void OnDisable()
    {
        dataTableTopMenu.OnCloseButtonClick += ClosePanel;
    }

    public void ClosePanel()
    {
        dataTableRoot.SetActive(false);
    }

    public void OpenPanel()
    {
        dataTableRoot.SetActive(true);
    }
    
    // Map의 데이터를 선택했을 때, MapDataTable Close
    private void MapDataSelected()
    {
        Debug.Log("Map Data Selected!!");
        OnCloseDataTable?.Invoke();
    }
}
