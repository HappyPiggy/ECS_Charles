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

    public CollisionDetectionSystem(Contexts contexts,IEntityFactoryService entityFactoryService) : base(contexts.game)
    {
        this.contexts = contexts;
        this.entityFactoryService = entityFactoryService as EntityFactoryService;
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
        foreach (var item in entities)
        {
            if (item.hasEnemyInfo) //敌人相关碰撞
            {
                EnemyCollision(item);
            }
            else if (item.hasPlayerInfo)  //有关角色的碰撞
            {
                HeroCollision(item);
            }
        }
    }


    /// <summary>
    /// 敌人相关碰撞
    /// </summary>
    /// <param name="item"></param>
    private void EnemyCollision(GameEntity item)
    {
        var collision = item.onTriggerEnter.collision;
        var tag = collision.gameObject.tag;
        BaseView view = collision.gameObject.GetComponent<BaseView>();

        switch (tag)
        {

            case "PlayerItem":
                Debug.Log("xx");
                break;
            default:
                // Debug.Log("未知碰撞体 :" + tag);
                break;
        }
    }

    /// <summary>
    /// 主角相关碰撞
    /// </summary>
    /// <param name="item"></param>
    private void HeroCollision(GameEntity item)
    {
        heroEntity = contexts.game.globalHero.value;

        var collision = item.onTriggerEnter.collision;
        var tag = collision.gameObject.tag;
        BaseView view = collision.gameObject.GetComponent<BaseView>();

        switch (tag)
        {
            //怪物移动才进行碰撞检测
            case "Enemy":
                if (view != null && view.gameEntity.isMover && !heroEntity.isInvincible)
                    heroEntity.ReplaceDead(true);
                break;

            case "Item"://碰到相同道具效果不叠加
                        //  Debug.Log(view.gameEntity.typeIndex.value);
                var type = view.gameEntity.itemType.value;
                if (type != heroEntity.itemType.value)
                {
                    entityFactoryService.CreatePlayerItem(UidUtils.Uid, heroEntity.position.value, (int)type);
                    heroEntity.ReplaceItemType(type);
                }

                view.gameEntity.isDestroyed = true;
                break;
            default:
                Debug.Log("未知碰撞体 :" + tag);
                break;

        }
    }



}



