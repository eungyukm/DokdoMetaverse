using Newtonsoft.Json.Linq;
using UnityEngine;

[System.Serializable]
public class PositionObject
{
    public float latitude;
    public float longitude;

    public PositionObject()
    {
        
    }

    public PositionObject(float pointLatitude, float pointLongitude)
    {
        latitude = pointLatitude;
        longitude = pointLongitude;
    }

    public PositionObject(JToken jToken)
    {
        // Debug.Log("[PositionObject] jToken : " + jToken.ToString());
        latitude = float.Parse(jToken[0].ToString());
        longitude = float.Parse(jToken[1].ToString());
    }

    public JArray Serialize()
    {
        JArray jArray = new JArray();
        jArray.Add(latitude);
        jArray.Add(longitude);
        
        return jArray;
    }

    public override string ToString()
    {
        return longitude + "," + latitude;
    }

    public float[] ToArray()
    {
        float[] array = new float[2];

        array[0] = longitude;
        array[1] = latitude;

        return array;
    }
}
