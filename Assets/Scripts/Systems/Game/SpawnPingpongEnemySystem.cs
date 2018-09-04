using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// pingpong类型怪物生成系统
/// 难度为normal时生成
/// </summary>
public class SpawnPingpongEnemySystem : IExecuteSystem
{
    private Contexts contexts;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;
    private GameEntity heroEntity;

    private MapInfo mapInfo;

    private  int enemyCnt = -1;  //怪物的上下层数量
    private readonly float yGap = 1f; //怪物y间隔
    private readonly float xGap =1f; //怪物x间隔
    private float speed = 0.2f; //怪物移动速度

    private float timer = 0;
    private float interval = 4;

    private List<Vector2> posList = new List<Vector2>();
    private List<GameEntity> pingPongEnemyList = new List<GameEntity>();
    private EnemyBehavior enemyBehavior;


    public SpawnPingpongEnemySystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.entityFactoryService = services.entityFactoryService as EntityFactoryService;
        this.configService = services.configService;
    }




    public void Execute()
    {
        if (contexts.game.gameDifficulty.state >= GameDifficulty.Normal)
        {
            //ReSpawnEnemy();

            if (ConstantUtils.isDestroySpawnPingpong)
            {
                ConstantUtils.isDestroySpawnPingpong = false;
                DestroyPingpongEnemy();
            }


            if (ConstantUtils.isStartSpawnPingpong)
            {
                ConstantUtils.isStartSpawnPingpong = false;
                enemyCnt = Mathf.Min(enemyCnt + 1, 5);
                interval = Mathf.Min(interval+0.5f,8);
                SpawnHorizontalPingpongEnemy();
                SpawnVerticalPingpongEnemy();
            }


            timer += Time.deltaTime;
            if (timer > interval)
            {
                ConstantUtils.isDestroySpawnPingpong = true;
                ConstantUtils.isStartSpawnPingpong = true;
                timer = 0;
            }


        }


        if (contexts.game.gameProgress.state == GameProgressState.GameRestart)
        {
            timer = 0;
            enemyCnt = -1;
            interval = 4;
            CleanAllEnemy();
        }

    }

    /// <summary>
    /// 生成横向pingpong敌人
    /// </summary>
    /// <param name="count"></param>
    private void SpawnHorizontalPingpongEnemy()
    {
        var pos = GetStartPosition(true);
        for (int i = 0; i < pos.Length; i++)
        {
            enemyBehavior = new EnemyBehavior();
            enemyBehavior.pingpongBehavior = PingpongBehavior.Horizontal;
            var entity=entityFactoryService.CreateEnemy(UidUtils.Uid, pos[i], EnemyType.PingpongBehavior, enemyBehavior, speed);
            pingPongEnemyList.Add(entity);
        }
       
    }

    /// <summary>
    /// 生成纵向pingpong敌人
    /// </summary>
    /// <param name="count"></param>
    private void SpawnVerticalPingpongEnemy()
    {
        var pos = GetStartPosition(false);
        for (int i = 0; i < pos.Length; i++)
        {
            enemyBehavior = new EnemyBehavior();
            enemyBehavior.pingpongBehavior = PingpongBehavior.Vertical;
            var entity = entityFactoryService.CreateEnemy(UidUtils.Uid, pos[i], EnemyType.PingpongBehavior, enemyBehavior,speed);
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
            if(pingPongEnemyList[i].hasEnemyInfo)
                pingPongEnemyList[i].ReplaceEnemyState(EnemyState.Die);
        }
        CleanAllEnemy();
    }


    /// <summary>
    /// 怪物死后立即生成
    /// </summary>
    //private void ReSpawnEnemy()
    //{
    //    for (int i = 0; i < pingPongEnemyList.Count; i++)
    //    {
    //        if (!pingPongEnemyList[i].hasEnemyInfo)
    //        {
    //            var index = i % posList.Count;
    //            posList[index] = new Vector2(-posList[index].x, posList[index].y);
    //            pingPongEnemyList[i]= entityFactoryService.CreateEnemy(UidUtils.Uid, posList[index], EnemyType.PingpongBehavior);
    //        }
                
    //    }
    //}

    /// <summary>
    /// 清除pingpong敌人所有引用数据
    /// </summary>
    private void CleanAllEnemy()
    {
        posList.Clear();

        for (int i = 0; i < pingPongEnemyList.Count; i++)
        {
            pingPongEnemyList[i] = null;
        }
        pingPongEnemyList.Clear();

    }

    /// <summary>
    /// 获得初始位置
    /// </summary>
    /// <param name="isHorizontal">是横向还是纵向</param>
    /// <returns></returns>
    private Vector2[] GetStartPosition(bool isHorizontal)
    {
        posList.Clear();
        heroEntity = contexts.game.globalHero.value;

        if (mapInfo == null)
            mapInfo = configService.GetMapInfo();


        if (isHorizontal)
        {
            float x = MathUtils.RandomInt(0, 2) == 1 ? mapInfo.border.maxX : mapInfo.border.minX;
            float y = heroEntity.position.value.y;

            posList.Add(new Vector3(x,y));
            for (int i = 1; i <= enemyCnt; i++)
            {
                var dis = i * yGap;
                x = -x;
                Vector2 pos = new Vector2(x, y + dis);
                posList.Add(pos);
                pos = new Vector2(x, y - dis);
                posList.Add(pos);
            }

        }
        else
        {
            float x = heroEntity.position.value.x;
            float y = MathUtils.RandomInt(0, 2) == 1 ? mapInfo.border.minY : mapInfo.border.maxY;

            posList.Add(new Vector3(x, y));

            for (int i = 1; i <= enemyCnt; i++)
            {
                var dis = i * xGap;
                y = -y;
                Vector2 pos = new Vector2(x+dis, y);
                posList.Add(pos);
                pos = new Vector2(x-dis,y);
                posList.Add(pos);
            }
        }

        return posList.ToArray();
    }
}
