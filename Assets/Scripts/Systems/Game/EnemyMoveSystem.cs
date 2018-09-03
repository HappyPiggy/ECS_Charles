using DG.Tweening;
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
    EnemyBehavior behavior = new EnemyBehavior();


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
                var type = enemy.enemyType.value;
                switch (type)
                {
                    case EnemyType.NormalBehavior:
                        NormalEnemeyMove(enemy);
                        break;
                    case EnemyType.PingpongBehavior:
                        //交给自身的view处理移动
                       // PingPongEnemeyMove(enemy);
                        break;
                    default:
                        break;
                }

            }
            
        }

    }


    /// <summary>
    /// pingpong类型敌人的移动
    /// </summary>
    /// <param name="enemy"></param>
    private void PingPongEnemeyMove(GameEntity enemy)
    {
        switch (behavior.pingpongBehavior)
        {
            case PingpongBehavior.Horizontal:
                break;
            case PingpongBehavior.Vertical:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 普通敌人的移动
    /// </summary>
    /// <param name="enemy"></param>
    private void NormalEnemeyMove(GameEntity enemy)
    {
        if (enemy.isMover)
        {
            var dir = GetNormalEnemyDirection(heroEntity, enemy);
            var dis = (heroEntity.position.value - enemy.position.value).magnitude;

            if (dis > 1e-3)
            {
                var newPos = enemy.position.value + dir * enemy.speed.value * Time.deltaTime;
                enemy.ReplacePosition(newPos);
            }
        }
    }


    /// <summary>
    /// 根据敌人状态得到运动方向
    /// </summary>
    /// <param name="hero"></param>
    /// <param name="enemy"></param>
    /// <returns></returns>
    private Vector2 GetNormalEnemyDirection(GameEntity hero,GameEntity enemy)
    {
        //根据player当前道具 改变敌人状态
        var cnt = heroEntity.playerItemList.value.Count-1;
        var itemType =  hero.playerItemList.value[cnt];

       
        
        switch (itemType)
        {
            case ItemType.Shield:
                behavior.normalBehavior = NormalBehavior.Chase;
                break;
            case ItemType.MachineGun:
                behavior.normalBehavior = NormalBehavior.Flee;
                break;
            default:
                behavior.normalBehavior = NormalBehavior.Chase;
                break;
        }
        enemy.ReplaceEnemyBehavior(behavior);


        //根据敌人状态改变运动方向
        var type =  enemy.enemyBehavior.value.normalBehavior;
        Vector2 dir = Vector2.zero;
        switch (type)
        {
            case NormalBehavior.Chase:
                dir = (hero.position.value - enemy.position.value).normalized;
                break;
            case NormalBehavior.Flee:
                dir = -(hero.position.value - enemy.position.value).normalized;
                break;
            default:
                break;
        }
        return dir;

    }



}
