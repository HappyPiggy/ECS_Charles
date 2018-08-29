using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生成系统
/// </summary>
public class SpawnRandomEnemySystem : IExecuteSystem
{
    private Contexts contexts;
    private Services services;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;

    private MapInfo mapInfo;

    private float timer =999;


    public SpawnRandomEnemySystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.services = services;
        this.entityFactoryService = services.entityFactoryService as EntityFactoryService;
        this.configService = services.configService;
    }




    public void Execute()
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            if (timer > contexts.game.enemySpawnIntervalTime.value)
            {
                //todo 需要一个系统来管理每次生成怪物的数量和间隔时间
                var count = MathUtils.RandomInt(2,8);
                var time = MathUtils.RandomFloat(0.5f, 1.5f);
                contexts.game.ReplaceEnemySpawnCount(count);
                contexts.game.ReplaceEnemySpawnIntervalTime(time);

                SpawnRandomEnemy(contexts.game.enemySpawnCount.value);
                timer = 0;
            }
            timer += Time.deltaTime;
        }else if (contexts.game.gameProgress.state == GameProgressState.GameRestart)
        {
            timer = 999; //立即生成第一波怪
        }

    }

    /// <summary>
    /// 随机生成敌人
    /// </summary>
    /// <param name="count"></param>
    private void SpawnRandomEnemy(int count)
    {
        while (count > 0)
        {
            //不在主角身上生成敌人 防止立即碰到
            Vector2 pos = Vector2.zero;
            do
            {
                pos = GetRandomPosition();
            } while (pos == contexts.game.globalHero.value.position.value);

            entityFactoryService.CreateEnemy(UidUtils.Uid, pos,EnemyType.Random);
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
