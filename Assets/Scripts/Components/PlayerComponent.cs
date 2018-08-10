using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class HeroComponent : IComponent
{
}

[Game]
public class PositionComponent : IComponent
{
    public Vector2 value;
}

[Game]
public class PlayerSpeedComponent : IComponent
{
    public float value;
}


[Game]
public class RotationComponent : IComponent
{
    public Quaternion value;
}

[Game]
public class ViewComponent : IComponent
{
    public IView instance;
}

[Game]
public class SpriteComponent : IComponent
{
    public string name;
}

[Game]
public class MoverComponent : IComponent
{
}

[Game]
public class MoveComponent : IComponent
{
    public Vector2 target;
}

