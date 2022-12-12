using UnityEngine;

[CreateAssetMenu]
public class SO_Goods : ScriptableObject
{
    public string title;
    public string price;
    [TextArea(15,20)]
    public string summary;
    public Sprite thumbnail;
    //public Sprite titleImage;
}