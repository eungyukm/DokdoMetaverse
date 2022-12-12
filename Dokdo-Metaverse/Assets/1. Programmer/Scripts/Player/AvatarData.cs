using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gender { Female, Male }

[System.Serializable]
public struct AvatarInfo
{
    public GameObject prefab;
    public Sprite image;
}

[CreateAssetMenu(menuName = "SO/AvatarData")]
public class AvatarData : ScriptableObject
{
    public Gender playerGender;

    public int playerAvatarIndex;

    public List<AvatarInfo> maleAvatars; 
    public List<AvatarInfo> femaleAvatars; 
}
