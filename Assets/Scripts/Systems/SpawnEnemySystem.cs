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
                //todo 需要一个系统来管理每次生成怪物的数量和间隔时间
                var count = MathUtils.RandomInt(2, 4);
                var time = MathUtils.RandomFloat(0.5f, 1.5f);
                contexts.game.ReplaceEnemySpawnCount(count);
                contexts.game.ReplaceEnemySpawnIntervalTime(time);

                SpawnEnemyRandom(contexts.game.enemySpawnCount.value);
                timer = 0;
            }
        }

    }

    /// <summary>
    /// 随机生成敌人
    /// </summary>
    /// <param name="count"></param>
    private void SpawnEnemyRandom(int count)
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            while (count > 0)
            {
                var pos = GetRandomPosition();
                entityFactoryService.CreateEnemy(UidUtils.Uid, pos);
                count--;
            }
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
