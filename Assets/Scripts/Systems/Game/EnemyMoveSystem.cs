using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物移动系统
/// </summary>
public class EnemyMoveSystem : IExecuteSystem, IInitializeSystem
{
    private Contexts contexts;
    private ConfigService configService;

    private IGroup<GameEntity> enemyGroup;
    private GameEntity heroEntity;


    public EnemyMoveSystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.configService = services.configService;
    }


    public void Initialize()
    {
        enemyGroup = contexts.game.GetGroup(GameMatcher.EnemyInfo);
    }



    public void Execute()
    {

        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            heroEntity = contexts.game.globalHero.value;

            foreach (var enemy in enemyGroup.GetEntities())
            {
                if (enemy.isMover)
                {
                    var dir = GetEnemyDirection(heroEntity, enemy);
                    var dis = (heroEntity.position.value - enemy.position.value).magnitude;

                    if (dis > 1e-3)
                    {
                        var newPos = enemy.position.value + dir * enemy.speed.value * Time.deltaTime;
                        enemy.ReplacePosition(newPos);
                    }
                }
            }
            
        }

    }

    /// <summary>
    /// 根据敌人状态得到运动方向
    /// </summary>
    /// <param name="hero"></param>
    /// <param name="enemy"></param>
    /// <returns></returns>
    private Vector2 GetEnemyDirection(GameEntity hero,GameEntity enemy)
    {
        //根据player当前道具 改变敌人状态
        var itemType = hero.itemType.value;
        switch (itemType)
        {
            case ItemType.Shield:
                enemy.ReplaceEnemyType(EnemyType.Normal);
                break;
            case ItemType.MachineGun:
                enemy.ReplaceEnemyType(EnemyType.Flee);
                break;
            default:
                enemy.ReplaceEnemyType(EnemyType.Normal);
                break;
        }


        //根据敌人状态改变运动方向
        var type = enemy.enemyType.value;
        Vector2 dir = Vector2.zero;
        switch (type)
        {
            case EnemyType.Normal:
                dir = (hero.position.value - enemy.position.value).normalized;
                break;
            case EnemyType.Flee:
                dir = -(hero.position.value - enemy.position.value).normalized;
                break;
            default:
                break;
        }
        return dir;

    }



}
