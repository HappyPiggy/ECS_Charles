using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Meta,Unique]
public class InputServiceComponent : IComponent
{
    public IInputService instance;
}
