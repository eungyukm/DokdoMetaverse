using UnityEngine;
using UnityEngine.EventSystems;

// GeoPoint를 선택하는 클래스
public class PointSelecter : MonoBehaviour
{
    public GameObject point;
    public GeoPoint selectedPoint = null;
    private LayerMask _layerMask;
    public Material blue;
    public Material white;

    public bool _isPointClicked = false;

    public GameObject GISRightMenu;

    private void Start()
    {
        _layerMask = LayerMask.GetMask("Point");

        Init();
    }

    private void Init()
    {
        GISRightMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isPointClicked)
            {
                SetPointPosition();
            }
            else
            {
                GetPointObject();
            }
        }
    }
    
    // 
    public void GetPointObject()
    {
        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        // UI 클릭시 이벤트 막음
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(Physics.Raycast(ray, out var hitData, Mathf.Infinity, _layerMask))
        {
            ClearMaterial();
            point = hitData.transform.gameObject;
            selectedPoint = point.GetComponent<GeoPoint>();
            
            ChangeMaterial();
            _isPointClicked = true;
            
            GISRightUI(true);
        }
        else
        {
            _isPointClicked = false;
            point = null;
            selectedPoint = null;
            
            GISRightUI(false);
        }
    }
    
    // Point의 Material을 원래 색상으로 초기화
    private void ClearMaterial()
    {
        if (point == null)
        {
            return;
        }

        point.GetComponent<MeshRenderer>().material = white;
    }
    
    // Point의 Material을 클릭했을 경우의 색상으로 변경
    private void ChangeMaterial()
    {
        if (point == null)
        {
            return;
        }

        point.GetComponent<MeshRenderer>().material = blue;
    }
    
    // Raycast로 point를 위치를 변경합니다.
    private void SetPointPosition()
    {
        if (point == null)
        {
            return;
        }
        
        // UI 클릭시 이벤트 막음
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if(Physics.Raycast(ray, out hitData))
        {
            GeoPoint geoPoint = point.GetComponent<GeoPoint>();
            geoPoint.SetPosition(hitData.point);

            ClearMaterial();
            _isPointClicked = false;
            point = null;
            
            GISRightUI(false);
        }
    }
    
    // 포인트를 지울 때 호출하는 메서드
    public void DeletePoint()
    {
        Debug.Log("DeletPoint!!");
        _isPointClicked = false;
        point = null;
        selectedPoint = null;
    }
    
    // 오른쪽 GISUI
    private void GISRightUI(bool toggle)
    {
        GISRightMenu.SetActive(toggle);
    }
}
