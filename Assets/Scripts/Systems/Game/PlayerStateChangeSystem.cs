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
  //  private IGroup<GameEntity> enemyGroup;

    private float timer = 0;

    public PlayerStateChangeSystem(Contexts contexts)
    {
        this.contexts = contexts;
      //  enemyGroup = contexts.game.GetGroup(GameMatcher.EnemyInfo);
    }


    public void Execute()
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            heroEntity = contexts.game.globalHero.value;
            var type = heroEntity.playerItemList.value.Peek(); //取得人物最后吃得的道具
            switch (type)
            {
                case ItemType.Shield:  //开启无敌 防止人物移动速度过快导致立即死亡
                    heroEntity.isInvincible = true;
                    heroEntity.isMover = true;
                    timer = 0;
                    break;
                case ItemType.MachineGun: //机枪状态人物不能移动 怪物躲避
                    heroEntity.isMover = false;
                    heroEntity.isInvincible = true;
                    timer = 0;
                    break;
                case ItemType.None:
                    heroEntity.isMover = true;
                    timer += Time.deltaTime;
                    if(timer>=ConstantUtils.invincibleTime)
                         heroEntity.isInvincible = false;
                    break;
                default:
                    Debug.Log("未知类型 :" + type);
                    break;
            }
        }
        
    }

}



