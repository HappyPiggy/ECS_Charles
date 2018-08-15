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
        enemyGroup = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EnemyState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.enemyState.value == EnemyState.Die || entity.enemyState.value == EnemyState.Move;
    }

    protected override void Execute(List<GameEntity> entities)
    {
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
                var pos = enemy.position.value;
                var index = (int)enemy.uID.value % (enemy.enemyInfo.value.enemyList.Length);

                ColorInfo colorInfo = new ColorInfo();
                colorInfo.color = ConstantUtils.spiltColorList[index];
                entityFactoryService.CreateSpilt(UidUtils.Uid, pos, colorInfo);
            }
        }
    }
}
