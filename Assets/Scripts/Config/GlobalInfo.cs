﻿using System;
using UnityEngine;

[Serializable]
public class GlobalInfo : ScriptableObject
{
    public PlayerInfo playerInfo;
    public MapInfo mapInfo;
    public EnemyInfo enemyInfo;
    public SpiltInfo spiltInfo;
}


[Serializable]
public class BaseInfo : ScriptableObject
{
    public ulong uid;
    public string resName;
    public GameObject prefab;
}

