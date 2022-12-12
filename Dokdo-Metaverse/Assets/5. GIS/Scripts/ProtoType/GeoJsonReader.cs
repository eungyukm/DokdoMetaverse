using UnityEngine;

public class GeoJsonReader : MonoBehaviour
{
    public LineRenderer lr;
    
    // private void Start()
    // {
    //     var geojson = Resources.Load("Datas/MapSample.geojsonl") as TextAsset;
    //     FeatureCollection featureCollection = FeatureObject.Deserialize(geojson.text);
    //
    //     CoordConverter coordConverter = new CoordConverter();
    //     double[] geometryXY = coordConverter.WGS84ToUTMK(featureCollection);
    //     Vector3[] worldPosition = coordConverter.UTMKToWorldPosition(geometryXY);
    //     SelectGroundRay(worldPosition);
    // }
    //
    // // 하늘에서 쏘는 RayCast
    // private void SelectGroundRay(Vector3[] Positions)
    // {
    //     RaycastHit hit;
    //     for (int i = 0; i < Positions.Length; i++)
    //     {
    //         if (Physics.Raycast(Positions[i], Vector3.down, out hit, Mathf.Infinity))
    //         {
    //             Positions[i].y = hit.point.y + 0.05f;
    //         }           
    //     }
    //
    //     DrawLine(Positions);
    // }
    //
    // // Line Renderer로 Line 그리기
    // private void DrawLine(Vector3[] Positions)
    // {
    //     lr.positionCount = Positions.Length;
    //
    //     for (int i = 0; i < Positions.Length; i++)
    //     {
    //         lr.SetPosition(i, Positions[i]);
    //     }
    // }
}
