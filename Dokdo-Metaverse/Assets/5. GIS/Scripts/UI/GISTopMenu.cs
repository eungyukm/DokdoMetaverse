using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GISTopMenu : MonoBehaviour
{
    public Button dataTableBtn;
    public Button utmkBtn;
    public Button kodeBtn;
    public Button ksignBtn;
    public Button mapAreaBtn;
    public Button saveBtn;

    public GameObject utmKpopup;
    public GameObject nkPopup;
    public GameObject mapAreaPopup;
    public DataTable dataTable;

    // 표지판
    public GameObject kSignRefence;
    public GameObject kSign;

    private bool _dataTableToggle = false; 
    private bool _utmkToggle = false;
    private bool _nkKodeToggle = false;
    private bool _mapAreaToggle = false;
    
    private bool _signMoveMode = false;
    

    public UTMKReader utmkReader;
    public LineRendererManager lineRendererManager;
    public GeoJsonCollection geoJsonCollection;
    
    public TMP_InputField mapAreaText;

    private void OnEnable()
    {
        dataTable.OnCloseDataTable += DataTableClicked;
    }

    private void OnDisable()
    {
        dataTable.OnCloseDataTable -= DataTableClicked;
    }

    private void Start()
    {
        dataTableBtn.onClick.AddListener(DataTableClicked);
        utmkBtn.onClick.AddListener(UtmkButtonClicked);
        kodeBtn.onClick.AddListener(NkButtonClicked);
        ksignBtn.onClick.AddListener(KSignButtonClicked);
        mapAreaBtn.onClick.AddListener(MapAreaButtonClicked);
        saveBtn.onClick.AddListener(SaveButtonClicked);
        
        InitButtonState();
    }
    
    // 전체 버튼의 상태를 초기화
    private void InitButtonState()
    {
        _dataTableToggle = false; 
        _utmkToggle = false;
        _nkKodeToggle = false;
        _mapAreaToggle = false;
        
        utmKpopup.SetActive(false);
        nkPopup.SetActive(false);
        mapAreaPopup.SetActive(false);
    }

    private void DataTableClicked()
    {
        if (!_dataTableToggle)
        {
            dataTable.OpenPanel();
        }
        else
        {
            dataTable.ClosePanel();
        }

        _dataTableToggle = !_dataTableToggle;
    }

    private void UtmkButtonClicked()
    {
        if (!_utmkToggle)
        {
            utmKpopup.SetActive(true);
        }
        else
        {
            utmKpopup.SetActive(false);
        }
        _utmkToggle = !_utmkToggle;
    }

    private void NkButtonClicked()
    {
        if (!_nkKodeToggle)
        {
            nkPopup.SetActive(true);
        }
        else
        {
            nkPopup.SetActive(false);
        }

        _nkKodeToggle = !_nkKodeToggle;
    }
    
    // 마우스 위치를 계속 따라가다가 좌 클릭할 경우, 해당 위치에 배치
    private void KSignButtonClicked()
    {
        kSign = Instantiate(kSignRefence);
        _signMoveMode = true;
    }
    
    // 국가지점 표지판 이동
    private void MoveSign()
    {
        if (kSign == null)
        {
            return;
        }

        if (!_signMoveMode)
        {
            return;
        }
        
        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            kSign.transform.position = raycastHit.point;
            kSign.GetComponent<KCodeSign>().SetKCode(utmkReader.kcode);
        }
    }
    
    // 국가지점표지판 배치 완료
    private void CompleteDepolyment()
    {
        if (Input.GetMouseButton(0))
        {
            _signMoveMode = false;
        }
    }
    
    // 면적 계산 버튼 클릭
    private void MapAreaButtonClicked()
    {
        if (lineRendererManager.selectedPolygon == null)
        {
            return;
        }
        
        if (!_mapAreaToggle)
        {
            float area = lineRendererManager.GetPolygonAreaBySelectedIndex();
            mapAreaText.text = area.ToString();
            mapAreaPopup.SetActive(true);
        }
        else
        {
            mapAreaPopup.SetActive(false);
        }
        _mapAreaToggle = !_mapAreaToggle;
    }
    
    // 저장 버튼 클릭
    private void SaveButtonClicked()
    {
        geoJsonCollection.SaveData();
    }

    private void Update()
    {
        if (_signMoveMode)
        {
            MoveSign();
            CompleteDepolyment();
        }
    }
}
