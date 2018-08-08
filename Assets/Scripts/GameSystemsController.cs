using Entitas;
using UnityEngine;
/// <summary>
/// ecs系统控制器
/// </summary>
public class GameSystemsController : Feature
{
    private Services services;
    private Contexts contexts;

    public  GameSystemsController(Contexts contexts)
    {

        InitService(contexts);

        Add(new InitConfigSystem(contexts,services.config));
        Add(new MovementSystems(contexts));

        //test
        contexts.game.ReplaceGameProgress(GameProgressState.ParseConfig);
    }



    /// <summary>
    /// 初始化所有服务
    /// </summary>
    private void InitService(Contexts contexts)
    {
        UnityInputService inputService = new UnityInputService();
        ConfigService configService = new ConfigService();
        UnityViewService unityViewService = new UnityViewService(contexts);


        services = new Services(inputService,
                                configService,
                                unityViewService);
    }
}