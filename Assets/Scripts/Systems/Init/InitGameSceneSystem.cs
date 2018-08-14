﻿using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏场景初始化系统
/// </summary>
public class InitGameSceneSystem : ReactiveSystem<GameEntity>
{
    private GameContext context;
    private EntityFactoryService entityFactoryService;

    public InitGameSceneSystem(Contexts contexts, IEntityFactoryService entityFactoryService) : base(contexts.game)
    {
        this.context = contexts.game;
        this.entityFactoryService = entityFactoryService as EntityFactoryService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameProgress);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.gameProgress.state == GameProgressState.StartGame;
    }


    protected override void Execute(List<GameEntity> entities)
    {
        //创建玩家
        ulong uid = 0;
        Vector2 playerSpawnPos = new Vector2(0, 4);
        Quaternion playerRotation = Quaternion.identity;
        entityFactoryService.CreatePlayer(uid, playerSpawnPos, playerRotation);


        //创建游戏地图
        uid = 1;
        entityFactoryService.CreateMap(uid);

        //初始化游戏场景配置
        context.ReplaceEnemySpawnCount(2);
        context.ReplaceEnemySpawnIntervalTime(2);

        context.ReplaceGameProgress(GameProgressState.InGame);
    }


}
