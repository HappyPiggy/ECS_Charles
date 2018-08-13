using System;
using UnityEngine;

[Serializable]
public class MapInfo : ScriptableObject
{
    public ulong uid;
    public string resName;
    [SerializeField]
    public Border border;
    public GameObject prefab;
}


public class Border
{
    public float minX, maxX, minY, maxY;
    public Border(float minX,float maxX,float minY,float maxY)
    {
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
    }
}