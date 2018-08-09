using Entitas;
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
public class PlayerInfoComponent : IComponent
{
    public PlayerInfo value;
}