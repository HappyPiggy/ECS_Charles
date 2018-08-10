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
        else
        {
            gameEntity = CreateBasePlayer(uid);
        }

        gameEntity.ReplacePosition(spawnPos);
        gameEntity.ReplaceRotation(rotation);

        PlayerInfo playerInfo = configService.GetPlayerInfo();
        gameEntity.ReplacePlayerInfo(playerInfo);
        gameEntity.ReplacePlayerSpeed(playerInfo.playerConfig.moveSpeed);


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
        gameEntity.AddAsset("Player");

        gameEntity.isMover = true;
        gameEntity.isDestroyed = false;
        gameEntity.isHero = true;

        return gameEntity;
    }


    /// <summary>
    /// 判断entity是否还有view
    /// 彻底清除entity
    /// </summary>
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