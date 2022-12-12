using UnityEngine;
using UnityEngine.UI;

public class GISRightMenu : MonoBehaviour
{
    public Button addPointBtn;

    public Button deletePointBtn;

    public PointSelecter pointSelecter;
    public LineRendererManager LineRendererManager;
    
    void Start()
    {
        addPointBtn.onClick.AddListener(AddPointButtonClicked);
        deletePointBtn.onClick.AddListener(DeletePointButtonClicked);
    }

    private void AddPointButtonClicked()
    {
        
    }

    private void DeletePointButtonClicked()
    {
        if (pointSelecter != null)
        {
            int selectedIndex = pointSelecter.selectedPoint.index;
            
            // Line을 지웠으므로 null 처리
            pointSelecter.DeletePoint();
            
            LineRendererManager.selectedPolygon.DeleteGeoPointByIndex(selectedIndex);
            LineRendererManager.DeleteLine(selectedIndex);

            LineRendererManager.ResetIndex();
        }
        else
        {
            Debug.LogError("Selected Point is null");
        }
    }
}
