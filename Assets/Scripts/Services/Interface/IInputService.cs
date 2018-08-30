using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService  {

	Vector2 FreeMoveJoystick { get; }
    Vector2 NormalMoveJoystick { get; }
}
