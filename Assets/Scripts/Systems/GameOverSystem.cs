using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 处理游戏结束
/// </summary>
public class GameOverSystem : ReactiveSystem<GameEntity>,IInitializeSystem
{
    private Contexts contexts;

    private IGroup<GameEntity> enemyGroup;

    public GameOverSystem(Contexts contexts ) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    public void Initialize()
    {
        enemyGroup = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Dead);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isHero == true;
    }


    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var enemy in enemyGroup.GetEntities())
        {
            if (enemy.isEnable)
            {
                enemy.ReplaceEnemyState(EnemyState.Die);
                enemy.ReplaceDead(true);
                enemy.isMover = false;
            }
        }
        contexts.game.ReplaceGameProgress(GameProgressState.GameOver);
    }


}
