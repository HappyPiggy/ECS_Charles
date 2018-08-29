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
        enemyGroup = contexts.game.GetGroup(GameMatcher.Asset);
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
        ModuleManager.Instance.Hide(ModuleType.InGamePad);
        contexts.game.ReplaceGameProgress(GameProgressState.GameOver);

        foreach (var item in enemyGroup.GetEntities())
        {
            //消除屏幕上的敌人
            if (item.hasEnemyInfo)
            {
                if (item.isEnable)
                {
                    item.ReplaceEnemyState(EnemyState.Die); //不能放在敌人自身view的dead回调中。因为dead回调后立马回收。其他系统将检测不到敌人的死亡状态。
                    item.ReplaceDead(true);
                }
            }
            else if (item.hasItemInfo || item.hasItemType) //消除道具
            {
                item.isDestroyed = true;
            }

        }

       
    }


}
