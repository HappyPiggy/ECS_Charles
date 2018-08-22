﻿using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人物吃道具后的道具表现效果
/// </summary>
public class PlayerItemSystem : IExecuteSystem, IInitializeSystem
{
    private Contexts contexts;
    private Services services;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;

    private GameEntity heroEntity;
    private IGroup<GameEntity> itemGroup;



    public PlayerItemSystem(Contexts contexts, Services services)
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
            heroEntity = contexts.game.globalHero.value;

            foreach (var item in itemGroup.GetEntities())
            {
                if (item.unitType.value == UnitType.PlayerItem)
                {
                    var type = item.itemType.value;
                    switch (type)
                    {
                        case ItemType.Shield://如果是保护罩 就一直跟着player
                            if (item.hasPosition)
                                 item.ReplacePosition(heroEntity.position.value);
                            break;

                        case ItemType.MachineGun:
                            heroEntity.isMover = false;
                            heroEntity.ReplacePosition(item.position.value);
                            item.ReplaceRotation(heroEntity.view.instance.objTransform.rotation);
                            break;
                        case ItemType.None:

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