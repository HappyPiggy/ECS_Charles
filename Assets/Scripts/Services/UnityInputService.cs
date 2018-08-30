using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏中输入的接口集合
/// </summary>
public class UnityInputService : IInputService {

    //速度随手指移动速度变
    public Vector2 FreeMoveJoystick
    {
        get
        {
            return ControlPad.Distance;
        }
    }

    //速度恒定
    public Vector2 NormalMoveJoystick
    {
        get
        {
            return ControlPad.Direction;
        }
    }
}
