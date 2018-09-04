using Entitas;
using UnityEngine;
/// <summary>
/// ecs系统控制器
/// </summary>
public class GameSystemsController : Feature
{
    private Services services;
    private Contexts contexts;

    public GameSystemsController(Contexts contexts)
    {

        InitService(contexts);

        //init
        Add(new InitConfigSystem(contexts, services.configService));
        Add(new InitGameSceneSystem(contexts, services));


        //input
        Add(new EmitInputSystem(contexts, services.inputService));

        //in game
        Add(new GameDifficultyChangeSystem(contexts, services));
        Add(new SpawnNormalEnemySystem(contexts, services));
        Add(new EnemyMoveSystem(contexts, services));
        Add(new SpawnPingpongEnemySystem(contexts, services));
      //  Add(new SpawnCustomizedEnemySystem(contexts, services));
        Add(new CollisionDetectionSystem(contexts, services.entityFactoryService));
        Add(new ChangeMoveDirectionSystem(contexts, services.configService));
        Add(new SpawnItemSystem(contexts, services));
        Add(new PlayerItemSystem(contexts, services));
        Add(new PlayerStateChangeSystem(contexts));
        Add(new ScoreSystem(contexts,services));


        //end
        Add(new GameOverSystem(contexts));
        Add(new SpawnSpiltSystem(contexts,services));
        Add(new GameEndSystem(contexts,services));


        // eventListener
        Add(new EventSystems(contexts));

        //clean
        Add(new EntityDestroySystem(contexts));

    }



    /// <summary>
    /// 初始化所有服务
    /// </summary>
    private void InitService(Contexts contexts)
    {
        UnityInputService inputService = new UnityInputService();
        ConfigService configService = new ConfigService();
        UnityViewService unityViewService = new UnityViewService(contexts);
        EntityFactoryService entityFactoryService = new EntityFactoryService(contexts, configService);
        UnityAudioService unityAudioService = new UnityAudioService();

        contexts.meta.ReplaceInputService(inputService);
        contexts.meta.ReplaceEntityFactoryService(entityFactoryService);
        contexts.meta.ReplaceUnityAudioService(unityAudioService);
        contexts.meta.ReplaceConfigService(configService);

        services = new Services(inputService,
                                configService,
                                unityViewService,
                                entityFactoryService,
                                unityAudioService);
    }
}