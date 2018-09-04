using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏战斗流程，难度控制
/// </summary>
public class GameDifficultyChangeSystem : IExecuteSystem
{
    private Contexts contexts;
    private Services services;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;

    private MapInfo mapInfo;
    private EnemyBehavior enemyBehavior = new EnemyBehavior();

    private float timer = 0;
    private bool isRepeat = false;


    public GameDifficultyChangeSystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.services = services;
        this.entityFactoryService = services.entityFactoryService as EntityFactoryService;
        this.configService = services.configService;
    }




    public void Execute()
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            timer += Time.deltaTime;
            if (timer>0 && timer<20)
            {
                contexts.game.ReplaceGameDifficulty(GameDifficulty.Easy);
            }else if (timer > 20)
            {
                contexts.game.ReplaceGameDifficulty(GameDifficulty.Normal);
            }
        }
        else if (contexts.game.gameProgress.state == GameProgressState.GameRestart)
        {
            ConstantUtils.isStartSpawnPingpong = false;
            timer = 0; //立即生成第一波怪
        }

    }

}
