using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInputService : IInputService {


    public Vector2 MoveJoystick
    {
        get
        {
            return ControlPad.Direction;
        }
    }

}
