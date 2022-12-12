using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeoPolygon : MonoBehaviour
{
    public int polygonIndex = 0;
    public List<GeoPoint> geoPoints = new List<GeoPoint>();
    
    public UnityAction<int, int> OnPolygonChange;

    public void AddGeoPoint(GeoPoint geoPoint)
    {
        geoPoints.Add(geoPoint);
        geoPoint.OnPositionChange += ChangedPointPostion;
    }
    
    // GeoPoint의 Positon이 변경 되었을 경우, Call
    private void ChangedPointPostion(int index)
    {
        OnPolygonChange?.Invoke(polygonIndex, index);
    }
    
    // GeoPoint의 중심을 계산하는 함수
    public Vector3 CalcuateCenterPositon()
    {
        Vector3 sum = Vector3.zero;
        foreach (var geoPoint in geoPoints)
        {
            // Debug.Log("geoPoints : " + geoPoint.positon);
            sum += geoPoint.positon;
        }
        // Debug.Log("sum : " + sum);
        return sum /= geoPoints.Count;
    }
    
    // 면적을 계산하는 함수
    public float GetPolygonArea()
    {
        float polygonArea = 0f;

        int firstIndex;
        int secondIndex;
        int listCount = geoPoints.Count;

        GeoPoint firstPoint;
        GeoPoint secondPoint;

        float factor = 0f;

        for (firstIndex = 0; firstIndex < listCount; firstIndex++)
        {
            secondIndex = (firstIndex + 1) % listCount;

            firstPoint = geoPoints[firstIndex];
            secondPoint = geoPoints[secondIndex];

            factor = ((firstPoint.positon.x * secondPoint.positon.z) - (secondPoint.positon.x * firstPoint.positon.z));
            polygonArea += factor;
        }

        polygonArea /= 2f;
        
        Debug.Log("polygonArea : " + polygonArea);
        return polygonArea;
    }
    
    // GeoPoint를 삭제하는 로직
    public void DeleteGeoPointByIndex(int index)
    {
        Destroy(geoPoints[index].gameObject); 
        geoPoints.RemoveAt(index);
    }
}
