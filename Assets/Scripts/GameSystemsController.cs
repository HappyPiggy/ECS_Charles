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
        Add(new InitGameSceneSystem(contexts, services.entityFactoryService));


        //input
        Add(new EmitInputSystem(contexts, services.inputService));

        //in game
        Add(new CollisionDetectionSystem(contexts));
        Add(new SpawnEnemySystem(contexts, services)); 
        Add(new EnemyMoveSystem(contexts, services));
        Add(new ChangeMoveDirectionSystem(contexts, services.configService));
        Add(new SpawnItemSystem(contexts, services));


        //end
        Add(new GameOverSystem(contexts));
        Add(new SpawnSpiltSystem(contexts,services));
        Add(new GameEndSystem(contexts));


        // eventListener
        Add(new EventSystems(contexts));

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

        contexts.meta.ReplaceInputService(inputService);
        contexts.meta.ReplaceEntityFactoryService(entityFactoryService);
    
        services = new Services(inputService,
                                configService,
                                unityViewService,
                                entityFactoryService);
    }
}