using System.Collections.Generic;
using UnityEngine;

public class LineRendererManager : MonoBehaviour
{
    public List<GeoPolygon> geoPolygons = new List<GeoPolygon>();
    public GeoPolygon selectedPolygon = null;

    private int selectedIndex = -1;

    // geoPolygon의 중심점 반환하는 함수
    public Vector3 GetPolygonCenterPosition(int index)
    {
        SelectLineByIndex(index);
        return selectedPolygon.CalcuateCenterPositon();
    }
    
    // geoPolygon의 면적 계산하여 반환하는 함수
    public float GetPolygonAreaByIndex(int index)
    {
        SelectLineByIndex(index);
        return selectedPolygon.GetPolygonArea();
    }
    
    // 선택된 폴리곤의 면적을 계산하여 반환하는 함수
    public float GetPolygonAreaBySelectedIndex()
    {
        SelectLineByIndex(selectedIndex);
        return selectedPolygon.GetPolygonArea();
    }
    
    // 라인 렌더러의 리스트에서 index에 따른 라인 선택
    private void SelectLineByIndex(int index)
    {
        selectedIndex = index;
        
        DeSelectLine();
        selectedPolygon = geoPolygons[index];
        LineRenderer lineRenderer = selectedPolygon.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
    }
    
    // 이전 라인 취소
    private void DeSelectLine()
    {
        if (selectedPolygon != null)
        {
            LineRenderer lineRenderer = selectedPolygon.gameObject.GetComponent<LineRenderer>();
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;

            selectedPolygon = null;
        }
    }
    
    // 라인 제거
    public void DeleteLine(int index)
    {
        if (selectedPolygon != null)
        {
            LineRenderer lineRenderer = selectedPolygon.gameObject.GetComponent<LineRenderer>();
            
            for (int i = 0; i < selectedPolygon.geoPoints.Count; i++)
            {
                lineRenderer.positionCount = selectedPolygon.geoPoints.Count;
                lineRenderer.SetPosition(i, selectedPolygon.geoPoints[i].positon);
            }
        }
    }

    public GeoPolygon GetSelectedPolygon()
    {
        if (selectedPolygon != null)
        {
            return selectedPolygon;
        }
        else
        {
            Debug.LogError("Selected Polygon is null!!");
            return null;
        }
    }

    public void ResetIndex()
    {
        for (int i = 0; i < selectedPolygon.geoPoints.Count; i++)
        {
            selectedPolygon.geoPoints[i].SetIndex(i);
        }
    }
}
