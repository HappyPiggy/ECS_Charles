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

    private Transform viewObjectRoot;

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
        heroEntity = contexts.game.globalHero.value;

        if(viewObjectRoot == null)
            viewObjectRoot = GameObject.Find("Game").transform;

        foreach (var item in entities)
        {
            if (item.hasOnTriggerEnter)
            {
                if (item.hasUnitType && item.unitType.value == UnitType.PlayerItem && !item.isHero) //人物携带道具相关碰撞
                {
                    PlayerItemCollisionEnter(item);
                }
                else if (item.isHero)  //角色相关碰撞
                {
                    HeroCollisionEnter(item);
                }
            }

        }
    }




    /// <summary>
    /// 敌人碰撞带道具的player
    /// </summary>
    /// <param name="item">人物身上的道具</param>
    private void PlayerItemCollisionEnter(GameEntity item)
    {
        var collision = item.onTriggerEnter.collision;
        var type = item.itemType.value;
        BaseView view = collision.gameObject.GetComponent<BaseView>();

        switch (type)
        {
            case ItemType.Shield://保护罩碰到怪物后 保护罩消失
                if (view.gameEntity.isMover)
                {
                    MissileEffect(heroEntity.position.value);
                    item.ReplaceItemType(ItemType.None);
                }
                break;
            case ItemType.MachineGun://机关枪按理说碰不到怪物
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
    private void HeroCollisionEnter(GameEntity item)
    {
        var collision = item.onTriggerEnter.collision;
        if (collision != null)
        {
            var tag = collision.gameObject.tag;
            BaseView view = collision.gameObject.GetComponent<BaseView>();

            switch (tag)
            {
                case "Enemy": //怪物移动才进行碰撞检测
                    if (view != null && view.gameEntity.isMover && !heroEntity.isInvincible)
                        heroEntity.ReplaceDead(true);
                    break;

                case "Item"://碰到相同道具效果叠加
                    var type = view.gameEntity.itemType.value;

                    entityFactoryService.CreatePlayerItem(UidUtils.Uid, heroEntity.position.value, (int)type);
                    heroEntity.ReplaceItemType(type);

                    view.gameEntity.isDestroyed = true;
                    break;
                case "PlayerItem": //携带道具时 player身上效果
                    break;
                case "Effect": // 道具被怪物碰掉后的特效
                    break;

                default:
                    Debug.Log("未知碰撞体 :" + collision.gameObject.name);
                    break;

            }
        }
  
    }

    /// <summary>
    /// 保护罩破裂后产生爆炸效果
    /// </summary>
    /// <param name="spawnPos"></param>
    private void MissileEffect(Vector3 spawnPos)
    {
        var res = Resources.Load("Unit/Effect/Missile");
        GameObject go = GameObject.Instantiate(res,spawnPos,Quaternion.identity,viewObjectRoot) as GameObject;
        go.name = res.name;
        go.AddComponent<MissileView>();
    }
    


}



