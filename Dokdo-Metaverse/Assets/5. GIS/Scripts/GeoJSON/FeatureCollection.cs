using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

[System.Serializable]
public class FeatureCollection : GeoJSONObject
{
    public List<FeatureObject> features;

    public FeatureCollection(string encodedString)
    {
        features = new List<FeatureObject>();
        JObject jObject = JObject.Parse(encodedString);
        ParseFeatures(jObject["features"]);
        type = "FeatureCollection";
    }

    public FeatureCollection(JObject jObject) : base(jObject)
    {
        features = new List<FeatureObject>();
        
        ParseFeatures(jObject["features"]);
    }

    public FeatureCollection()
    {
        features = new List<FeatureObject>();
        type = "FeatureCollection";
    }

    protected void ParseFeatures(JToken jToken)
    {
        foreach (var token in jToken)
        {
            string json = token.ToString();
            features.Add(new FeatureObject(JObject.Parse(json)));
        }
    }

    protected override JObject SerializeContent()
    {
        JObject jsonFeatureCollection = new JObject();
        jsonFeatureCollection.Add("type","FeatureCollection");
        jsonFeatureCollection.Add("name", "MapData");

        JObject crs = new JObject();
        crs.Add("type", "name");
        JObject crsProperties = new JObject();
        crsProperties.Add("name", "urn:ogc:def:crs:EPSG::5186");
        crs.Add("properties",crsProperties);
        
        jsonFeatureCollection.Add("crs", crs);
        
        JArray jsonFeatureArray = new JArray();
        Debug.Log("features Count : " + features.Count);
        
        foreach (FeatureObject feature in features)
        {
            JObject jFeature = feature.Serialize();
            jsonFeatureArray.Add(jFeature);
            
        }
        jsonFeatureCollection.Add("features", jsonFeatureArray);
        return jsonFeatureCollection;
    }
}
