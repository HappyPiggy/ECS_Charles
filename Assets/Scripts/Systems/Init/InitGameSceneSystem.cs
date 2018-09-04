using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏场景初始化系统
/// </summary>
public class InitGameSceneSystem : ReactiveSystem<GameEntity>
{
    private GameContext context;
    private EntityFactoryService entityFactoryService;
    private UnityAudioService unityAudioService;
    private ConfigService configService;

    public InitGameSceneSystem(Contexts contexts,Services services) : base(contexts.game)
    {
        this.context = contexts.game;
        this.entityFactoryService = services.entityFactoryService as EntityFactoryService;
        unityAudioService = services.audioService as UnityAudioService;
        configService = services.configService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameProgress);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.gameProgress.state == GameProgressState.StartGame;
    }


    protected override void Execute(List<GameEntity> entities)
    {
        //创建玩家
        Vector2 playerSpawnPos = new Vector2(0, 4);
        Quaternion playerRotation = Quaternion.identity;
        entityFactoryService.CreatePlayer(UidUtils.Uid, playerSpawnPos, playerRotation);

        //创建游戏地图
        entityFactoryService.CreateMap(UidUtils.Uid);

        //初始化游戏场景配置
        context.ReplaceEnemySpawnCount(2);
        context.ReplaceEnemySpawnIntervalTime(2);

        //创建控制摇杆
        ModuleManager.Instance.Show(ModuleType.ControlPad);
        //创建游戏内UI
        ModuleManager.Instance.Show(ModuleType.InGamePad);

        context.ReplaceGameProgress(GameProgressState.InGame);
        context.ReplaceGameDifficulty(GameDifficulty.None);

        //播放bgm
        unityAudioService.PlayMusic(configService.GetAudio("bgm"));
        
    }


}
