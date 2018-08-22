using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 人物吃道具后状态转变控制
/// </summary>

public class PlayerStateChangeSystem : IExecuteSystem
{
    private Contexts contexts;
    private GameEntity heroEntity;

    private float timer = 0;
    private float invincibleTime = 0.5f;

    public PlayerStateChangeSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }


    public void Execute()
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            heroEntity = contexts.game.globalHero.value;
            var type = heroEntity.itemType.value;
            switch (type)
            {
                case ItemType.Shield:  //开启无敌 防止人物移动速度过快导致立即死亡
                    heroEntity.isInvincible = true;
                    timer = 0;
                    break;
                case ItemType.MachineGun:
                    heroEntity.isInvincible = true;
                    timer = 0;
                    break;
                case ItemType.None:
                    timer += Time.deltaTime;
                    if(timer>=invincibleTime)
                         heroEntity.isInvincible = false;
                    break;
                default:
                    Debug.Log("未知类型 :" + type);
                    break;
            }
        }

        
    }
}



