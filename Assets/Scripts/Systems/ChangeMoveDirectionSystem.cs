using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 手柄数据填充到playerentity的方向中
/// </summary>
public class ChangeMoveDirectionSystem : ReactiveSystem<InputEntity>,IInitializeSystem
{
    private Contexts contexts;
    private InputContext context;
    private InputEntity controlPadInputEntity;
    private IGroup<GameEntity> heroGroup;

    public ChangeMoveDirectionSystem(Contexts contexts) : base(contexts.input)
    {
        this.contexts = contexts;
        context = contexts.input;
    }

    public void Initialize()
    {
        context.isControlPadInput = true;
        controlPadInputEntity = context.controlPadInputEntity;

        heroGroup = contexts.game.GetGroup(GameMatcher.Hero);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.MoveJoyStick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var rotation=MathUtils.Vector2Quaternion(controlPadInputEntity.moveJoyStick.value);
       // var res = -rotation.eulerAngles.y ;

        foreach (var item in heroGroup.GetEntities())
        {
            if (item.isHero)
            {
                item.ReplaceRotation(rotation);
            }
        }
    }




}
