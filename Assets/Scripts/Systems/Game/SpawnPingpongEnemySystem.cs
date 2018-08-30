using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// pingpong类型怪物生成系统
/// </summary>
public class SpawnPingpongEnemySystem : IExecuteSystem
{
    private Contexts contexts;
    private Services services;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;

    private MapInfo mapInfo;

    private int enemyCnt = 2;  //怪物的上下层数量
    private float gap = 1.5f; //怪物间隔

    private List<Vector2> posList = new List<Vector2>();
    private List<GameEntity> pingPongEnemyList = new List<GameEntity>();


    public SpawnPingpongEnemySystem(Contexts contexts, Services services)
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
            ReSpawnEnemy();

            if (ConstantUtils.isStartSpawnPingpong)
            {
                ConstantUtils.isStartSpawnPingpong = false;
                SpawnPingpongEnemy();
            }

            if (ConstantUtils.isDestroySpawnPingpong)
            {
                ConstantUtils.isDestroySpawnPingpong = false;
                DestroyPingpongEnemy();
            }
        }
        else if (contexts.game.gameProgress.state == GameProgressState.GameRestart)
        {
            CleanAllEnemy();
        }

    }

    /// <summary>
    /// 生成敌人
    /// </summary>
    /// <param name="count"></param>
    private void SpawnPingpongEnemy()
    {
        var pos = GetStartPosition();
        for (int i = 0; i < pos.Length; i++)
        {
            var entity=entityFactoryService.CreateEnemy(UidUtils.Uid, pos[i], EnemyType.Pingpong);
            pingPongEnemyList.Add(entity);
        }
       
    }

    /// <summary>
    /// 销毁所有pingpong敌人
    /// </summary>
    private void DestroyPingpongEnemy()
    {
        for (int i = 0; i < pingPongEnemyList.Count; i++)
        {
            pingPongEnemyList[i].ReplaceEnemyState(EnemyState.Die);
            pingPongEnemyList[i].ReplaceDead(true);
        }
        CleanAllEnemy();
    }


    /// <summary>
    /// 怪物死后立即生成
    /// </summary>
    private void ReSpawnEnemy()
    {
        for (int i = 0; i < pingPongEnemyList.Count; i++)
        {
            if (!pingPongEnemyList[i].hasEnemyInfo)
            {
                var index = i % posList.Count;
                pingPongEnemyList[i]= entityFactoryService.CreateEnemy(UidUtils.Uid, posList[index], EnemyType.Pingpong);
            }
                
        }
    }

    /// <summary>
    /// 清除pingpong敌人所有引用数据
    /// </summary>
    private void CleanAllEnemy()
    {
        posList.Clear();

        for (int i = 0; i < pingPongEnemyList.Count - 1; i++)
        {
            pingPongEnemyList[i] = null;
        }
        pingPongEnemyList.Clear();

    }

    /// <summary>
    /// 获得初始位置
    /// </summary>
    /// <returns></returns>
    private Vector2[] GetStartPosition()
    {
        if (mapInfo == null)
            mapInfo = configService.GetMapInfo();

        posList.Clear();

        float x = mapInfo.border.minX;
        float y = (mapInfo.border.minY+mapInfo.border.maxY)/2;

        posList.Add(new Vector3(x,y));

        for (int i = 1; i <= enemyCnt; i++)
        {
            var dis = i * gap;
            Vector2 pos = new Vector2(x, y + dis);
            posList.Add(pos);
            pos = new Vector2(x, y - dis);
            posList.Add(pos); 
        }

        return posList.ToArray();
    }
}
