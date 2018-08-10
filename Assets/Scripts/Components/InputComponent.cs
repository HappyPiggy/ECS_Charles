using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//对应ControlPad脚本
[Input, Unique]
public class ControlPadInputComponent : IComponent
{
}

[Input]
public class MoveJoyStickComponent : IComponent
{
    public Vector2 value;
}