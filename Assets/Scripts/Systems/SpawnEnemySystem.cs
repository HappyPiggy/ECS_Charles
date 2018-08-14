using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生成系统
/// </summary>
public class SpawnEnemySystem : IExecuteSystem,IInitializeSystem
{
    private Contexts contexts;
    private Services services;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;

    private MapInfo mapInfo;
    private IGroup<GameEntity> enemyGroup;

    private float timer = 0;
    private ulong uid = 0;


    public SpawnEnemySystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.services = services;
        this.entityFactoryService = services.entityFactoryService as EntityFactoryService;
        this.configService = services.configService;
    }


    public void Initialize()
    {
        enemyGroup = contexts.game.GetGroup(GameMatcher.Enemy);
    }



    public void Execute()
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            timer += Time.deltaTime;
            if (timer > contexts.game.enemySpawnIntervalTime.value)
            {
                SpawnEnemy(contexts.game.enemySpawnCount.value);
                timer = 0;
            }
        }

    }

    /// <summary>
    /// 生成敌人
    /// </summary>
    /// <param name="count"></param>
    private void SpawnEnemy(int count)
    {
        while (count > 0)
        {
            var pos = GetRandomPosition();
            entityFactoryService.CreateEnemy(uid, pos);
            uid++;
            count--;
        }
    }

    
    /// <summary>
    /// 获得随机合法位置
    /// </summary>
    /// <returns></returns>
    private Vector2 GetRandomPosition()
    {
        if (mapInfo == null)
            mapInfo = configService.GetMapInfo();

        float x = MathUtils.RandomFloat(mapInfo.border.minX, mapInfo.border.maxX);
        float y = MathUtils.RandomFloat(mapInfo.border.minY, mapInfo.border.maxY);
        Vector2 pos = new Vector2(x,y);

        return pos;
    }
}
