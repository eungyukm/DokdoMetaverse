using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityTemplateProjects;

public class MapDataContents : MonoBehaviour
{
    public GeoJsonCollection GeoJsonCollection;
    public List<MapItem> MapItems = new List<MapItem>();
    public List<GameObject> ItemObjects = new List<GameObject>();
    public GameObject ItemGO;
    public GameObject contents;
    public LineRendererManager lineRendererManager;

    public Camera mainCamera;

    public GameObject modifyPopUp;
    public DataTableModifyForm dataTableModifyForm;

    public TMP_InputField mapAreaText;

    public UnityAction OnMapDataSelected;

    private GameObject prevItemGO;
    
    void Start()
    {
        StartCoroutine(InitScrollView());
    }

    IEnumerator InitScrollView()
    {
        yield return new WaitForSeconds(1f);

        int count = GeoJsonCollection.GetFeatureCollectionsCount();
        // Debug.Log("count : " + count);
        for (int i = 0; i < count; i++)
        {
            MapItem mapItem = GeoJsonCollection.GetMapDataInFeatureCollection(i);
            MapItems.Add(mapItem);
        }
        
        AddMapItem();
        ListViewInit();
    }
    
    // Map의 item을 추가
    private void AddMapItem()
    {
        foreach (var mapItem in MapItems)
        {
            GameObject go = Instantiate(ItemGO);
            go.transform.parent = contents.transform;
            go.transform.localScale = Vector3.one;

            ItemObjects.Add(go);
        }
    }
    
    // 리스트 뷰의 데이터를 초기화
    private void ListViewInit()
    {
        int index = 0;
        foreach (var mapItem in MapItems)
        {
            MapItemSetter mapItemSetter = ItemObjects[index].GetComponent<MapItemSetter>();
            mapItemSetter.InitText(mapItem, index);
            mapItemSetter.OnSelectAction += SelectedItem;
            mapItemSetter.OnModifyAction += ModifyItem;
            
            index++;
        }
    }
    
    // Item의 map영역
    private void SelectedItem(int index, GameObject itemGO)
    {
        Vector3 positon = lineRendererManager.GetPolygonCenterPosition(index);
        
        mainCamera.GetComponent<SimpleCameraController>().enabled = false;
        mainCamera.transform.localPosition = new Vector3(positon.x, 30f, positon.z);
        mainCamera.GetComponent<SimpleCameraController>().enabled = true;

        float area = lineRendererManager.GetPolygonAreaByIndex(index);
        mapAreaText.text = area.ToString();

        if (prevItemGO != null)
        {
            DeSelectUI(prevItemGO);
        }
        SelectedUI(itemGO);
        prevItemGO = itemGO;

        OnMapDataSelected?.Invoke();
    }
    
    // 
    private void DeSelectUI(GameObject itemGO)
    {
        itemGO.GetComponent<Image>().color = Color.white;
    }
    
    // Material 변경
    private void SelectedUI(GameObject itemGO)
    {
        itemGO.GetComponent<Image>().color = new Color(0.5f, 0.6f, 0.9f);
    }

    private void ModifyItem(int index)
    {
        modifyPopUp.SetActive(true);
        dataTableModifyForm.OnComformClick += ModifyComplate;
        dataTableModifyForm.InitField(MapItems[index], index);
    }
    
    // 수정 완료
    private void ModifyComplate(MapItem mapItem, int index)
    {
        MapItems[index] = mapItem;
        dataTableModifyForm.gameObject.SetActive(false);

        ModifyItem(mapItem, index);
    }
    
    // 개별 map 데이터 반영
    private void ModifyItem(MapItem mapItem, int index)
    {
        MapItemSetter mapItemSetter = ItemObjects[index].GetComponent<MapItemSetter>();
        mapItemSetter.InitText(mapItem, index);
    }
}
