using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 销毁entity系统
/// 销毁掉destroy属性为true的entity 
/// </summary>
public interface IDestroyEntity : IEntity, IDestroyedEntity, IViewEntity { }

public partial class GameEntity : IDestroyEntity { }
public partial class InputEntity : IDestroyEntity { }

public class EntityDestroySystem : MultiReactiveSystem<IDestroyEntity, Contexts>
{
    public EntityDestroySystem(Contexts contexts) : base(contexts)
    {
    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[] {
            contexts.game.CreateCollector(GameMatcher.Destroyed),
            contexts.input.CreateCollector(InputMatcher.Destroyed)
        };
    }

    protected override bool Filter(IDestroyEntity entity)
    {
        return entity.isDestroyed;
    }

    protected override void Execute(List<IDestroyEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log("Destroyed Entity from " + e.contextInfo.name + " context");
            if (e.hasView)
            {
                var view = e.view.instance;
                view.OnDestroyedView();
            }
            e.Destroy();
        }
    }




}