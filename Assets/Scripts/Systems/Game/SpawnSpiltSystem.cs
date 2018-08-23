using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物死后的spilt生成
/// </summary>
public class SpawnSpiltSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private Contexts contexts;
    private Services services;

    private EntityFactoryService entityFactoryService;

    private IGroup<GameEntity> enemyGroup;

    public SpawnSpiltSystem(Contexts contexts,Services services) : base(contexts.game)
    {
        this.contexts = contexts;
        this.services = services;

        entityFactoryService = services.entityFactoryService as EntityFactoryService;
    }

    public void Initialize()
    {
        enemyGroup = contexts.game.GetGroup(GameMatcher.EnemyInfo);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EnemyState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.enemyState.value == EnemyState.Die || entity.enemyState.value == EnemyState.Move || entity.enemyState.value == EnemyState.None;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        //游戏结束的话所有enemy都要变成spilt 如果在战斗中则特定enemy变成spilt
        if (contexts.game.gameProgress.state == GameProgressState.GameOver)
        {
            foreach (var enemy in entities)
            {
                if (enemy.enemyState.value == EnemyState.Move)
                {
                    enemy.ReplaceEnemyState(EnemyState.Die);
                    enemy.ReplaceDead(true);
                    enemy.isMover = false;
                }
                CreateSpilt(enemy);
            }

            //弹出结算面板
            contexts.game.ReplaceGameProgress(GameProgressState.EndGame);
        }
        //游戏中敌人死亡
        else if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            foreach (var enemy in entities)
            {
                if (enemy.enemyState.value==EnemyState.Die)
                {
                    enemy.ReplaceDead(true);
                    enemy.isMover = false;
                    CreateSpilt(enemy);
                }
            }
        }
    }



    /// <summary>
    /// 创建spilt实体
    /// </summary>
    /// <param name="enemy"></param>
    private void CreateSpilt(GameEntity enemy)
    {
        var pos = enemy.position.value;
        var index = 0;
        if(enemy.hasColorType)
             index = enemy.colorType.value;
        entityFactoryService.CreateSpilt(UidUtils.Uid, pos, index);
    }
}
