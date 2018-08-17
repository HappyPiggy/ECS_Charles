using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Event(false)]
public class OnTriggerEnterComponent : IComponent
{
    public Collider2D collision;
}

[Event(false)]
public class OnTriggerExitComponent : IComponent
{
    public Collider2D collision;
}
