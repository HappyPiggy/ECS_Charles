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
    private UnityAudioService audioService;
    private ConfigService configService;

    public GameEndSystem(Contexts contexts,Services services) : base(contexts.game)
    {
        this.context = contexts.game;
        this.audioService = services.audioService as UnityAudioService;
        configService = services.configService;
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
        audioService.PlaySound(configService.GetAudio("beep_pop"));
        //停止背景音乐
        audioService.StopMusic();

    }


}
