using DG.Tweening;
using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏死亡后触发结算
/// </summary>
public class GameEndSystem : ReactiveSystem<GameEntity>
{
    private GameContext context;
    private EntityFactoryService entityFactoryService;

    public GameEndSystem(Contexts contexts) : base(contexts.game)
    {
        this.context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameProgress);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.gameProgress.state == GameProgressState.EndGame;
    }


    protected override void Execute(List<GameEntity> entities)
    {
        // ModuleManager.Instance.Show(ModuleType.EndGamePad);

    }


}
