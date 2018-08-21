using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 道具跟随人物
/// </summary>
public class PlayerItemFollowSystem : IExecuteSystem, IInitializeSystem
{
    private Contexts contexts;
    private Services services;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;

    private GameEntity heroEntity;
    private IGroup<GameEntity> itemGroup;



    public PlayerItemFollowSystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.services = services;
        this.entityFactoryService = services.entityFactoryService as EntityFactoryService;
        this.configService = services.configService;
    }


    public void Initialize()
    {
        itemGroup = contexts.game.GetGroup(GameMatcher.ItemType);
    }



    public void Execute()
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            if(heroEntity==null)
                heroEntity = contexts.game.globalHero.value;

            foreach (var item in itemGroup.GetEntities())
            {
                if (item.unitType.value == UnitType.PlayerItem)
                {
                    var type = item.itemType.value;
                    switch (type)
                    {
                        //如果是保护罩 就一直跟着player
                        case ItemType.Shield:
                            item.ReplacePosition(heroEntity.position.value);
                            break;
                        default:
                            Debug.Log("未知道具类型:" + type);
                            break;
                    }
                }
            }
        }


    }




}
