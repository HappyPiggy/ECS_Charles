using System;
using UnityEngine;


[Serializable]
public class PlayerConfig : ScriptableObject {

    public PlayerType type; //玩家类型
    public string name;
    public string desc;
    public float moveSpeed;
    public float size;
}
