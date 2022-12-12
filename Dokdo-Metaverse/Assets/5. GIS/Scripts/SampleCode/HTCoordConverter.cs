using UnityEngine;

public class HTCoordConverter : MonoBehaviour
{
    private void Start()
    {
        CoordConverter converter = new CoordConverter();
        string kcode = converter.WorldPositonToKcode(1387599.176629074, 1924687.6551367077);
        Debug.Log("kcode : " + kcode);
        
        TextAsset geojson = Resources.Load("Datas/MapSample.geojsonl") as TextAsset;
        FeatureCollection collection = GeoJSONObject.Deserialize(geojson.text);
        double[] utmkArray = converter.WGS84ToUTMK(collection);
        
        Vector3[] worldPositons = converter.UTMKToWorldPosition(utmkArray);
        Debug.Log("Length : " + worldPositons.Length);
        Debug.LogFormat("p{0} x:{1} y:{2} z:{3}", 0, worldPositons[0].x, worldPositons[0].y, worldPositons[0].z);

        double[] wgs84Array = converter.UTMKToWGS84(utmkArray);
        Debug.LogFormat("wgs84 p{0} x:{1} y:{2}", 0, wgs84Array[0], wgs84Array[1]);
    }
}
