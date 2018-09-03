using System;
using UnityEngine;

[Serializable]
public class GlobalInfo : ScriptableObject
{
    public PlayerInfo playerInfo;
    public MapInfo mapInfo;
    public NormalEnemyInfo normalEnemyInfo;
    public SpiltInfo spiltInfo;
    public ItemInfo itemInfo; //道具信息
    public ItemInfo playerItemInfo; //人物身上的道具
}


[Serializable]
public class BaseInfo : ScriptableObject
{
    public ulong uid;
    public string resName;
    public GameObject prefab;
}

