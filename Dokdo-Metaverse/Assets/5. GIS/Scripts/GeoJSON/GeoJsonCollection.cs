using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// GeoJson을 데이터를 관리하는 클래스
public class GeoJsonCollection : MonoBehaviour
{
    public LineRenderer lr;
    public FeatureCollection featureCollection;
    public List<FeatureObject> featureObjects = new List<FeatureObject>();
    public GameObject sphereGameObject;
    public GameObject lineRoot;
    public LineRendererManager lineRendererManager;

    private bool useLocalData = false;
    void Start()
    {
        if (useLocalData)
        {
            var geojson = Resources.Load("Datas/MapJSON.geojsonl") as TextAsset;
            string[] geojsonArry = geojson.text.Split('\n');

            GeoJsonToWgs84(geojsonArry);
        }
        else
        {
            string geojson = GISDataManager.GetInstance().LoadData("MapData");
            
            GeoJsonToWgs84(geojson);
        }
    }
    
    // GeoJson을 utmk로 변환
    private void GeoJsonToWgs84(string[] geojsonArry)
    {
        for (int i = 0; i < geojsonArry.Length - 1; i++)
        {
            FeatureObject featureObject = FeatureObject.Deserialize(geojsonArry[i]);
            featureObjects.Add(featureObject);
            
            
            CoordConverter coordConverter = new CoordConverter();
            double[] geometryXY = coordConverter.WGS84ToUTMK(featureObject);

            Vector3[] worldPosition = coordConverter.UTMKToWorldPosition(geometryXY);
            SelectGroundRay(worldPosition, i);
        }
        
        featureCollection = new FeatureCollection();
        featureCollection.features = featureObjects;
    }

    private void GeoJsonToWgs84(string geojson)
    {
        featureCollection = GeoJSONObject.Deserialize(geojson);
        featureObjects = featureCollection.features;

        for (int i = 0; i < featureCollection.features.Count; i++)
        {
            CoordConverter coordConverter = new CoordConverter();
            double[] geometryXY = coordConverter.WGS84ToUTMK(featureCollection.features[i]);

            Vector3[] worldPosition = coordConverter.UTMKToWorldPosition(geometryXY);
            SelectGroundRay(worldPosition, i);
        }
    }

    // 하늘에서 쏘는 RayCast
    private void SelectGroundRay(Vector3[] Positions, int idx)
    {
        RaycastHit hit;
        for (int i = 0; i < Positions.Length; i++)
        {
            if (Physics.Raycast(Positions[i], Vector3.down, out hit, Mathf.Infinity))
            {
                Positions[i].y = hit.point.y + 0.05f;
            }           
        }

        DrawLine(Positions, idx);
    }
    
    // Line Renderer로 Line 그리기
    private void DrawLine(Vector3[] positions, int idx)
    {
        LineRenderer lineRenderer = Instantiate(lr, lineRoot.transform, true);
        lineRenderer.positionCount = positions.Length;
        lineRenderer.transform.position = positions[0];

        lineRenderer.gameObject.AddComponent<GeoPolygon>();
        GeoPolygon geoPolygon = lineRenderer.GetComponent<GeoPolygon>();
        geoPolygon.polygonIndex = idx;
        for (int i = 0; i < positions.Length; i++)
        {
            GameObject sphere = Instantiate(sphereGameObject, lineRenderer.transform, true);
            sphere.transform.position = positions[i];
            GeoPoint geoPoint = sphere.GetComponent<GeoPoint>();
            geoPoint.index = i;
            geoPoint.SetPosition(positions[i]);
            geoPolygon.AddGeoPoint(geoPoint);
            lineRenderer.SetPosition(i, positions[i]);

            geoPolygon.OnPolygonChange += ChangedPolygon;
        }
        lineRendererManager.geoPolygons.Add(geoPolygon);
    }
    
    // GeoJson에서 feature데이터 중 연속 지적 데이터 추출
    public MapItem GetMapDataInFeatureCollection(int index)
    {
        Dictionary<string, string> dicProperties= featureObjects[index].properties;
        // Debug.Log("PNU : " + dicProperties["PNU"]);

        MapItem mapItem = new MapItem();
        mapItem.PNU = dicProperties["PNU"];
        mapItem.SID0_CD = dicProperties["SIDO_CD"];
        mapItem.SID0_NM = dicProperties["SIDO_NM"];
        mapItem.SGG_CD = dicProperties["SGG_CD"];
        mapItem.SGG_NM = dicProperties["SGG_NM"];
        mapItem.EMD_CD =dicProperties["EMD_CD"];
        mapItem.EMD_NM =dicProperties["EMD_NM"];
        mapItem.RI_CD = dicProperties["RI_CD"];
        mapItem.RI_NM = dicProperties["RI_NM"];
        
        return mapItem;
    }

    public int GetFeatureCollectionsCount()
    {
        return featureObjects.Count;
    }
    
    // Polygon의 데이터가 변경사항이 있을 때 호출되는 클래스
    private void ChangedPolygon(int polygonIndex, int pointIndex)
    {
        LineRenderer lr = lineRendererManager.geoPolygons[polygonIndex].gameObject.GetComponent<LineRenderer>();
        Vector3 pointPos = lineRendererManager.geoPolygons[polygonIndex].geoPoints[pointIndex].transform.position;
        lr.SetPosition(pointIndex, pointPos);
    }
    
    // 데이터 저장
    public void SaveData()
    {
        if (lineRendererManager.selectedPolygon != null)
        {
            int index = lineRendererManager.selectedPolygon.polygonIndex;
            string json = ModifyFeatureCollection(index);

            GISDataManager.GetInstance().SaveLocalData("MapData", json);
        }
    }
    
    // featureCollection 수정
    public string ModifyFeatureCollection(int index)
    {
        List<PositionObject> positionObjects = new List<PositionObject>();
        GeoPolygon geoPolygon = lineRendererManager.GetSelectedPolygon();
        CoordConverter coordConverter = new CoordConverter();
        
        Debug.Log("geoPolygon.geoPoints.Count : " + geoPolygon.geoPoints.Count);
        for (int i = 0; i < geoPolygon.geoPoints.Count; i++)
        {
            double[] utmkXY = coordConverter.GeoPointToUTMKInSaSA(geoPolygon.geoPoints[i]);
            double[] wgs84XY = coordConverter.UTMKToWGS84(utmkXY);
            PositionObject positionObject = new PositionObject((float)wgs84XY[0], (float)wgs84XY[1]);
            positionObjects.Add(positionObject);
        }
        Debug.Log("index : " + index);
        Debug.Log("positionObjects Count : " + positionObjects.Count);
        Debug.Log("Count : " + featureObjects.Count);

        ArrayGeometryObject arrayGeometryObject = new ArrayGeometryObject(positionObjects);
        featureCollection.features[index].geometry = arrayGeometryObject;

        foreach (var positionObject in featureCollection.features[index].geometry.AllPositions())
        {
            Debug.Log("trs : " + positionObject.latitude);
        }
        string json = featureCollection.Serialize().ToString();

        return json;
    }
}