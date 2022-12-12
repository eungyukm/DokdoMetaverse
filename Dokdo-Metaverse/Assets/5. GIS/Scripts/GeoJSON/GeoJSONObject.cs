using Newtonsoft.Json.Linq;
using UnityEngine;

public class GeoJSONObject
{
    public string type;

    public GeoJSONObject()
    {
    }

    public GeoJSONObject(JObject jObject)
    {
        if (jObject != null)
        {
            type = jObject["type"].ToString();
        }
    }

    public static FeatureCollection Deserialize(string encodedString)
    {
        FeatureCollection collection = null;
        Debug.Log("encodedString : " + encodedString);
        JObject jsonObject = JObject.Parse(encodedString);

        if (jsonObject["type"].ToString() == "FeatureCollection")
        {
            collection = new FeatureCollection(jsonObject);
        }
        else
        {
            collection = new FeatureCollection();
            collection.features.Add( new FeatureObject(jsonObject));
        }

        return collection;
    }

    public JObject Serialize()
    {
        JObject rootJObject = SerializeContent();
        return rootJObject;
    }

    protected virtual JObject SerializeContent()
    {
        return null;
    }
}