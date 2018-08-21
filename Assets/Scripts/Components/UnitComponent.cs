﻿using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class UIDComponent : IComponent
{
    [PrimaryEntityIndex]
    public ulong value;
}



[Game]
public class UnitTypeComponent : IComponent
{
    public UnitType value;
}

[Game]
public class ItemTypeComponent : IComponent
{
    public ItemType value;
}

[Game]
public class ColorTypeComponent : IComponent
{
    public int value;
}

[Game]
public class EnemyStateComponent : IComponent
{
    public EnemyState value;
}





[Game]
public class PlayerInfoComponent : IComponent
{
    public PlayerInfo value;
}

[Game]
public class MapInfoComponent : IComponent
{
    public MapInfo value;
}


[Game]
public class EnemyInfoComponent : IComponent
{
    public EnemyInfo value;
}

[Game]
public class SpiltInfoComponent : IComponent
{
    public SpiltInfo value;
}


[Game]
public class ItemInfoComponent : IComponent
{
    public ItemInfo value;
}