using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game,Unique,Event(false)]
public class GameProgressComponent : IComponent
{
    public GameProgressState state;
}


[Game, Unique, Event(false)]
public class GameDifficultyComponent : IComponent
{
    public GameDifficulty state;
}


