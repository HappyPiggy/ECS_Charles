using System;
using UnityEngine;


[Serializable]
public class BaseInfo : ScriptableObject
{
    public ulong uid;
    public string resName;
    public GameObject prefab;
}

[Serializable]
public class PlayerInfo : BaseInfo
{

    PlayerConfig playerConfig;
}
