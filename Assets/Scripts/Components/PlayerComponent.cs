using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class HeroComponent : IComponent
{
}

[Game]
public class EnemyComponent : IComponent
{
}

[Game,Event(true)]
public class DeadComponent : IComponent
{
}

[Game,Unique]
public class EnemySpawnCountComponent : IComponent
{
    public int value;
}

[Game, Unique]
public class EnemySpawnIntervalTimeComponent : IComponent
{
    public float value;
}

[Game]
public class PositionComponent : IComponent
{
    public Vector2 value;
}

[Game]
public class SpeedComponent : IComponent
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
public class MoverComponent : IComponent
{
}


