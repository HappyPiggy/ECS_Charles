using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game,Event(false)]
public class AssetComponent : IComponent
{
    public object value;
}
