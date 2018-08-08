using System;
using UnityEngine;


[Serializable]
public class PlayerConfig : ScriptableObject {

    public int id;
    public string name;
    public string desc;
    public float moveSpeed;
    public float size;
}
