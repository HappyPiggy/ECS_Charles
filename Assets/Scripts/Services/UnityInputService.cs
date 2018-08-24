using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏中输入的接口集合
/// </summary>
public class UnityInputService : IInputService {


    public Vector2 MoveJoystick
    {
        get
        {
            return ControlPad.Distance;
        }
    }

}
