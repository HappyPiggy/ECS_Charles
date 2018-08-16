using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 处理玩家死亡后的操作
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
        //消除屏幕上的敌人
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
