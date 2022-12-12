using System.Collections.Generic;
using UnityEngine;

public class CoordConverter
{
    private Dictionary<int, string> widthDictionary = new Dictionary<int, string>();
    private Dictionary<int, string> heightDictionary = new Dictionary<int, string>();

    public CoordConverter()
    {
        widthDictionary = new Dictionary<int, string>()
        {
            {7, "가"},
            {8, "나"},
            {9, "다"},
            {10, "라"},
            {11, "마"},
            {12, "바"},
            {13, "사"},
        };

        heightDictionary = new Dictionary<int, string>()
        {
            {13, "가"},
            {14, "나"},
            {15, "다"},
            {16, "라"},
            {17, "마"},
            {18, "바"},
            {19, "사"},
            {20, "아"},
        };
    }
    
    // UTM-K width와 height를 입력하면, 국가 지정 좌표로 변환하여 출력하는 로직
    public string WorldPositonToKcode(double width, double height)
    {
        string firstKCode;
        string secondKcode;

        int firstNumber = (int)width / 100000;
        int secondNumber = (int) height / 100000;

        if (firstNumber >= 7 && firstNumber <= 13)
        {
            firstKCode = widthDictionary[firstNumber];
        }
        else
        {
            Debug.LogError("국가지점번호의 입력 범위가 아닙니다.");
            return null;
        }

        if (secondNumber >= 13 && secondNumber <= 20)
        {
            secondKcode = heightDictionary[secondNumber];
        }
        else
        {
            Debug.LogError("국가지점번호의 입력 범위가 아닙니다.");
            return null;
        }
        int wp = (int)((width % 100000) / 10);
        int hp = (int)((height % 100000) / 10);

        string kCode = firstKCode + " "+ secondKcode + " " + wp.ToString() + " " + hp.ToString();
        return kCode;
    }
    
    // 사사 구역일 경우, 국가 지정 좌표로 변환
    public string WorldPositonToKcodeInSaSa(double width, double height)
    {
        int wp = (int)((width % 100000) / 10);
        int hp = (int)((height % 100000) / 10);

        string kCode = "사" + " "+ "사" + " " + wp.ToString() + " " + hp.ToString();
        
        return kCode;
    }
    
    // 사사 구열일 경우, 월드 좌표를 UTMK 좌표로 반환
    public string WorldPositonToUTMKInSaSa(double width, double height)
    {
        return "13" + width + " " + "19" + height;
    }
    
    // utm-k xy좌표에서 Unity World 좌표로 변환
    public Vector3[] UTMKToWorldPosition(double[] utmkXY)
    {
        int count = utmkXY.Length;

        Vector3[] worldPosition = new Vector3[count / 2];
        int worldCount = 0;
        for (int i = 0; i < count; i++)
        {
            worldPosition[worldCount].y = 1000f;
            if (i % 2 == 0)
            {
                worldPosition[worldCount].x = (float)(utmkXY[i]) % 100000;
            }
            else
            {
                worldPosition[worldCount].z = (float)(utmkXY[i]) % 100000;
                worldCount++;
            }
        }
        return worldPosition;
    }
    
    // WGS84에서 UTMK로 좌표 변환
    public double[] WGS84ToUTMK(FeatureCollection featureCollection)
    {
        double[] geometryXY = new double[featureCollection.features[0].geometry.PositionCount() * 2];
        int geometryCount = 0;
        foreach (var positionObject in featureCollection.features[0].geometry.AllPositions())
        {
            geometryXY[geometryCount] = positionObject.latitude;
            geometryXY[geometryCount + 1] = positionObject.longitude;
            geometryCount += 2;
        }
        
        double[] z = {0};
        
        string grs80 = "+proj=tmerc +lat_0=38 +lon_0=127.5 +k=0.9996 +x_0=1000000 +y_0=2000000 +ellps=GRS80 +units=m +no_defs";
        string wgs84 = "+title=WGS 84 (long/lat) +proj=longlat +ellps=WGS84 +datum=WGS84 +units=degrees";

        DotSpatial.Projections.ProjectionInfo src = DotSpatial.Projections.ProjectionInfo.FromProj4String(wgs84);
        DotSpatial.Projections.ProjectionInfo trg = DotSpatial.Projections.ProjectionInfo.FromProj4String(grs80);
        
        DotSpatial.Projections.Reproject.ReprojectPoints(geometryXY, z, src, trg, 0, geometryXY.Length / 2);
        // Debug.LogFormat("output UTM-K p{0} = {1} {2}", 0, geometryXY[0], geometryXY[1]);
        return geometryXY;
    }
    
    public double[] WGS84ToUTMK(FeatureObject featureObject)
    {
        double[] geometryXY = new double[featureObject.geometry.PositionCount() * 2];
        int geometryCount = 0;
        foreach (var positionObject in featureObject.geometry.AllPositions())
        {
            geometryXY[geometryCount] = positionObject.latitude;
            geometryXY[geometryCount + 1] = positionObject.longitude;
            geometryCount += 2;
        }
        
        double[] z = {0};
        
        string grs80 = "+proj=tmerc +lat_0=38 +lon_0=127.5 +k=0.9996 +x_0=1000000 +y_0=2000000 +ellps=GRS80 +units=m +no_defs";
        string wgs84 = "+title=WGS 84 (long/lat) +proj=longlat +ellps=WGS84 +datum=WGS84 +units=degrees";

        DotSpatial.Projections.ProjectionInfo src = DotSpatial.Projections.ProjectionInfo.FromProj4String(wgs84);
        DotSpatial.Projections.ProjectionInfo trg = DotSpatial.Projections.ProjectionInfo.FromProj4String(grs80);
        
        DotSpatial.Projections.Reproject.ReprojectPoints(geometryXY, z, src, trg, 0, geometryXY.Length / 2);
        // Debug.LogFormat("output UTM-K p{0} = {1} {2}", 0, geometryXY[0], geometryXY[1]);
        return geometryXY;
    }
    
    // UTMK 좌표에서 WGS84로 변환
    public double[] UTMKToWGS84(double[] utmkXY)
    {
        string grs80 =
            "+proj=tmerc +lat_0=38 +lon_0=127.5 +k=0.9996 +x_0=1000000 +y_0=2000000 +ellps=GRS80 +units=m +no_defs";
        string wgs84 = "+title=WGS 84 (long/lat) +proj=longlat +ellps=WGS84 +datum=WGS84 +units=degrees";
        
        double[] z = {0};
        
        DotSpatial.Projections.ProjectionInfo src = 
            DotSpatial.Projections.ProjectionInfo.FromProj4String(grs80);
        DotSpatial.Projections.ProjectionInfo trg = 
            DotSpatial.Projections.ProjectionInfo.FromProj4String(wgs84);
        
        DotSpatial.Projections.Reproject.ReprojectPoints(utmkXY, z, src, trg, 0, utmkXY.Length / 2);
        // Debug.LogFormat("output WGS84 p{0} = {1} {2}", 0, utmkXY[0], utmkXY[1]);

        return utmkXY;
    }
    
    // GeoPoint를 UTMK로 변환
    public double[] GeoPointToUTMK(GeoPoint geoPoint)
    {
        double[] utmkXY = new double[2];
        utmkXY[0] = geoPoint.positon.x;
        utmkXY[1] = geoPoint.positon.z;

        return utmkXY;
    }
    
    // GeoPoint를 UTMK로 변환 사사 구역 
    public double[] GeoPointToUTMKInSaSA(GeoPoint geoPoint)
    {
        double[] utmkXY = new double[2];
        utmkXY[0] = geoPoint.positon.x + 13 * 100000;
        utmkXY[1] = geoPoint.positon.z + + 19 * 100000;

        return utmkXY;
    }
}
