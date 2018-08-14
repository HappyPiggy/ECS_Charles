using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 加载配置文件系统
/// </summary>
public class InitConfigSystem : ReactiveSystem<GameEntity>
{
    private GameContext context;
    private ConfigService configService;

    public InitConfigSystem(Contexts contexts, ConfigService configService) : base(contexts.game)
    {
        this.context = contexts.game;
        this.configService = configService;

        contexts.game.ReplaceGameProgress(GameProgressState.ParseConfig);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameProgress);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.gameProgress.state == GameProgressState.ParseConfig;
    }


    protected override void Execute(List<GameEntity> entities)
    {
        LoadConfig();
    }

    /// <summary>
    /// 加载各种配置到service
    /// </summary>
    private void LoadConfig()
    {
        var globalInfo = Resources.Load("Config/GlobalInfo");
        configService.globalInfo = globalInfo as GlobalInfo;

        context.ReplaceGameProgress(GameProgressState.StartGame);
    }
}
