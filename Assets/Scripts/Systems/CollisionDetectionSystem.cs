using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 检测unity碰撞事件
/// </summary>

public class CollisionDetectionSystem : ReactiveSystem<GameEntity>,IInitializeSystem
{
    private Contexts contexts;
    private EntityFactoryService entityFactoryService;
    private GameEntity heroEntity;

    public CollisionDetectionSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    public void Initialize()
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.OnTriggerEnter, GameMatcher.OnTriggerExit));
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }


    protected override void Execute(List<GameEntity> entities)
    {
        //有关角色的碰撞
        heroEntity = contexts.game.globalHero.value;
        if (heroEntity.hasOnTriggerEnter)
        {
            var collision = heroEntity.onTriggerEnter.collision;
            var tag = collision.gameObject.tag;
            BaseView view = collision.gameObject.GetComponent<BaseView>();
            switch (tag)
            {
                //怪物移动才进行碰撞检测
                case "Enemy":
                    if(view!=null && view.gameEntity.isMover && !heroEntity.isInvincible)
                        heroEntity.ReplaceDead(true);
                    break;

                case "Item": 
                    break;

                default:
                    Debug.Log("未知碰撞体 :"+ tag);
                    break;

            }
        }



    }



}



