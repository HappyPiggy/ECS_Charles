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
    private Services services;
    private ConfigService configService;

    private IGroup<GameEntity> enemyGroup;
    private IGroup<GameEntity> heroGroup;


    public EnemyMoveSystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.services = services;
        this.configService = services.configService;
    }


    public void Initialize()
    {
        enemyGroup = contexts.game.GetGroup(GameMatcher.Enemy);
        heroGroup = contexts.game.GetGroup(GameMatcher.Hero);
    }



    public void Execute()
    {
        foreach (var hero in heroGroup.GetEntities())
        {
            foreach (var enemy in enemyGroup.GetEntities())
            {
                if (enemy.isMover)
                {
                    var dir = (hero.position.value - enemy.position.value).normalized;
                    var dis = (hero.position.value - enemy.position.value).magnitude;
                    if (dis > 1e-3)
                    {
                        var newPos = enemy.position.value + dir * enemy.speed.value * Time.deltaTime;
                        enemy.ReplacePosition(newPos);
                    }
                }
            }
        }
    }

}
