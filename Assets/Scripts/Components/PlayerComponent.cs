using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Unique,Event(false)]
public class GlobalHeroComponent : IComponent
{
    public GameEntity value;
}

[Game]
public class HeroComponent : IComponent
{
}


[Game,Event(true)]
public class DeadComponent : IComponent
{
    public bool value;
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

[Game]
public class EnableComponent : IComponent
{
}

[Game]
public class InvincibleComponent : IComponent
{
}
