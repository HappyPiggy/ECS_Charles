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

[Meta, Unique]
public class EntityFactoryServiceComponent : IComponent
{
    public  IEntityFactoryService instance;
}


[Meta, Unique]
public class UnityAudioServiceComponent : IComponent
{
    public UnityAudioService instance;
}

[Meta, Unique]
public class ConfigServiceComponent : IComponent
{
    public ConfigService instance;
}