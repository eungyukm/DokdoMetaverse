using UnityEngine;

// How To Deserialize GeoJSON
public class HTGeoJson : MonoBehaviour
{
    void Start()
    {
        TextAsset geojson = Resources.Load("Datas/MapSample.geojsonl") as TextAsset;
        FeatureCollection collection = GeoJSONObject.Deserialize(geojson.text);

        collection.Serialize();
    }
}