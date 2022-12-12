using System.Collections.Generic;
using UnityEngine;

// 다각형의 면적을 계산하는 클래스
public class HTPolygoneArea : MonoBehaviour
{
    private List<DoublePoint> sourceList = new List<DoublePoint>();

    private void Start()
    {
        sourceList.Add(new DoublePoint(50, 50));
        sourceList.Add(new DoublePoint(-50, 50));
        sourceList.Add(new DoublePoint(-50, -50));
        

        double polygonArea = GetPolygonArea(sourceList);
        Debug.Log("polygonArea : " + polygonArea);
    }
    
    // 다각형의 전체 면적 계산 코드
    public double GetPolygonArea(List<DoublePoint> sourceList)
    {
        double polygonArea = 0d;

        int firstIndex;
        int secondIndex;
        int sourceCount = sourceList.Count;

        DoublePoint firstPoint;
        DoublePoint secondPoint;

        double factor = 0d;

        for (firstIndex = 0; firstIndex < sourceCount; firstIndex++)
        {
            secondIndex = (firstIndex + 1) % sourceCount;

            firstPoint = sourceList[firstIndex];
            secondPoint = sourceList[secondIndex];

            factor = ((firstPoint.X * secondPoint.Y) - (secondPoint.X * firstPoint.Y));
            polygonArea += factor;
        }

        polygonArea /= 2d;
        
        return polygonArea;
    }
}

/// <summary>
/// 실수 포인트
/// </summary>
public class DoublePoint
{
    public double X {get; set;}
    public double Y { get; set;}

    public DoublePoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return string.Format("X={0},Y={1}", X, Y);
    }
}
