using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _moves;

    public MoveSystem(Contexts contexts)
    {
        _moves = contexts.game.GetGroup(GameMatcher.Move);
    }



    public void Execute()
    {
        foreach (GameEntity e in _moves.GetEntities())
        {

        }
    }
}
