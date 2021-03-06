﻿using Entitas.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 创建各种entity
/// </summary>
public class EntityFactoryService : IEntityFactoryService
{
    private GameContext context;
    private ConfigService configService;


    public EntityFactoryService(Contexts contexts, ConfigService config)
    {
        context = contexts.game;
        configService = config;
    }



    public GameEntity CreateCustomizedEnemy(ulong uid, Vector2 spawnPos, EnemyType type ,GameObject go)
    {
        CheckDuplicateEntity(uid);
        GameEntity gameEntity = context.CreateEntity();

        gameEntity.AddUID(uid);
        gameEntity.AddUnitType(UnitType.Enemy);
        gameEntity.AddPosition(spawnPos);
        gameEntity.AddRotation(Quaternion.identity);

        gameEntity.AddEnemyType(type);
        gameEntity.AddEnemyState(EnemyState.None);

        gameEntity.isDestroyed = false;

        gameEntity.AddAsset(go);

        return gameEntity;
    }



    /// <summary>
    /// 创造角色当前身上的道具
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="spawnPos"></param>
    /// <param name="itemType">当前吃的道具类型</param>
    /// <returns></returns>
    public GameEntity CreatePlayerItem(ulong uid, Vector2 spawnPos,int itemType)
    {
        CheckDuplicateEntity(uid);
        GameEntity gameEntity = context.CreateEntity();

        gameEntity.AddUID(uid);
        gameEntity.AddUnitType(UnitType.PlayerItem);
        gameEntity.AddItemType((ItemType)itemType,ItemType.None);
        gameEntity.AddPosition(spawnPos);
        gameEntity.AddRotation(Quaternion.identity);

        ItemInfo playerItemInfo = configService.GetPlayerItemInfo();
        gameEntity.AddItemInfo(playerItemInfo);

        gameEntity.AddAsset("PlayerItem");

        return gameEntity;
    }

    /// <summary>
    ///  创造地图上的道具
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="spawnPos"></param>
    /// <returns></returns>
    public GameEntity CreateItem(ulong uid,Vector2 spawnPos)
    {
        CheckDuplicateEntity(uid);
        GameEntity gameEntity = context.CreateEntity();

        gameEntity.AddUID(uid);
        gameEntity.AddUnitType(UnitType.Item);
        gameEntity.AddPosition(spawnPos);
        gameEntity.AddRotation(Quaternion.identity);

        ItemInfo itemInfo = configService.GetItemInfo();
        gameEntity.AddItemInfo(itemInfo);

        var index=MathUtils.RandomInt(0, (int)ItemType.None);
       // var index = 0;
        gameEntity.AddItemType((ItemType)index, (ItemType)index);

        gameEntity.AddAsset("Item");

        return gameEntity;
    }

    /// <summary>
    /// 创建敌人死亡后的涂鸦
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="spawnPos"></param>
    /// <param name="typeIndex"></param>
    /// <returns></returns>
    public GameEntity CreateSpilt(ulong uid,Vector2 spawnPos,int typeIndex)
    {
        CheckDuplicateEntity(uid);
        GameEntity gameEntity = context.CreateEntity();

        gameEntity.AddUID(uid);
        gameEntity.AddUnitType(UnitType.Spilt);
        gameEntity.AddPosition(spawnPos);

        Quaternion randomQuaternion = Quaternion.Euler(0, 0, MathUtils.RandomFloat(0, 360));
        gameEntity.AddRotation(randomQuaternion);
        gameEntity.AddEnemyState(EnemyState.None);

        SpiltInfo spiltInfo = configService.GetSpiltInfo();
        gameEntity.AddSpiltInfo(spiltInfo);
        gameEntity.AddColorType(typeIndex);

        gameEntity.AddAsset("Spilt");

        return gameEntity;
    }

    /// <summary>
    /// 创建敌人
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="spawnPos"></param>
    /// <param name="type">敌人的种类</param>
    /// <param name="behavior">对应敌人种类的行为</param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public GameEntity CreateEnemy(ulong uid, Vector2 spawnPos, EnemyType type, EnemyBehavior behavior,float speed=0 )
    {
        CheckDuplicateEntity(uid);
        GameEntity gameEntity = context.CreateEntity();

        gameEntity.AddUID(uid);
        gameEntity.AddUnitType(UnitType.Enemy);
        gameEntity.AddPosition(spawnPos);
        gameEntity.AddRotation(Quaternion.identity);

        gameEntity.AddEnemyType(type);
        gameEntity.AddEnemyState(EnemyState.None);
        gameEntity.AddEnemyBehavior(behavior);


        gameEntity.isDestroyed = false;

        NormalEnemyInfo enemyInfo = configService.GetEnemyInfo();
        gameEntity.AddEnemyInfo(enemyInfo);
        //如果需要动态更改则动态改 否则读配置
        if (speed != 0)
            gameEntity.AddSpeed(speed);
        else
            gameEntity.AddSpeed(enemyInfo.speed);

        gameEntity.AddAsset("Enemy");

        return gameEntity;
    }


    /// <summary>
    /// 创建游戏地图
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public GameEntity CreateMap(ulong uid)
    {
        CheckDuplicateEntity(uid);
        GameEntity gameEntity = context.CreateEntity();

        gameEntity.AddUID(uid);
        gameEntity.AddUnitType(UnitType.GameMap);
        gameEntity.AddPosition(Vector2.zero);
        gameEntity.AddRotation(Quaternion.identity);

        MapInfo mapInfo = configService.GetMapInfo();
        gameEntity.AddMapInfo(mapInfo);
        gameEntity.AddAsset("Map");

        return gameEntity;
    }

    /// <summary>
    /// 根据配置表信息创建一个player entity
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="spawnPos"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public GameEntity CreatePlayer(ulong uid, Vector2 spawnPos, Quaternion rotation)
    {
        GameEntity gameEntity = context.GetEntityWithUID(uid);
        if (gameEntity != null && gameEntity.isDestroyed)
        {
            DestroyEntity(gameEntity);
        }

        gameEntity = CreateBasePlayer(uid);

        gameEntity.ReplacePosition(spawnPos);
        gameEntity.ReplaceRotation(rotation);
        gameEntity.isInvincible = false; //不开启无敌


        var list = new List<ItemType>();
        list.Add(ItemType.None);
        gameEntity.ReplacePlayerItemList(list);


        PlayerInfo playerInfo = configService.GetPlayerInfo();
        gameEntity.ReplacePlayerInfo(playerInfo);
        gameEntity.ReplaceSpeed(playerInfo.playerConfig.moveSpeed);
        gameEntity.AddAsset("Player");

        context.ReplaceGlobalHero(gameEntity);

        return gameEntity;
    }


    /// <summary>
    /// 创建全新的player entity
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    private GameEntity CreateBasePlayer(ulong uid)
    {
        GameEntity gameEntity = context.CreateEntity();

        gameEntity.AddUID(uid);
        gameEntity.AddUnitType(UnitType.Player);
        gameEntity.AddPosition(Vector2.zero);
        gameEntity.AddRotation(Quaternion.identity);

        gameEntity.isMover = true;
        gameEntity.isDestroyed = false;
        gameEntity.isHero = true;

        return gameEntity;
    }

    private void CheckDuplicateEntity(ulong uid)
    {
        GameEntity gameEntity = context.GetEntityWithUID(uid);
        if (gameEntity != null && gameEntity.isDestroyed)
        {
            DestroyEntity(gameEntity);
        }
    }

    /// <summary>
    /// 如果存在遗留entity，则清除它身上链接的view后 destroy它自己
    /// </summary>
    /// <param name="gameEntity"></param>
    private void DestroyEntity(GameEntity gameEntity)
    {
        if (gameEntity.hasView)
        {
            var view = gameEntity.view.instance;
            view.OnDestroyedView();
        }

        gameEntity.Destroy();
    }
}