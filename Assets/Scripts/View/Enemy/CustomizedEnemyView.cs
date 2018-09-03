using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 预制体自定义敌人
/// </summary>
public class CustomizedEnemyView:BaseView,IDeadListener
{
    public void Start()
    {
        DoScale();
        Invoke("DelayMove", ConstantUtils.EnemyDelayMoveTime);

        gameEntity.AddDeadListener(this);
        gameEntity.isEnable = true;
    }



    protected override void Update()
    {
        //同步系统中的位置
        if (gameEntity != null && gameEntity.isMover && !isDestroyed)
        {
            gameEntity.ReplacePosition(transform.position);
        }
    }


    /// <summary>
    /// 延时移动
    /// </summary>
    private void DelayMove()
    {
        if (gameEntity.enemyState.value == EnemyState.None)
        {
            gameEntity.isMover = true;
            gameEntity.ReplaceEnemyState(EnemyState.Move);
        }
    }

    /// <summary>
    /// 逐渐变大
    /// </summary>
    private void DoScale()
    {
        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale, ConstantUtils.EnemyDelayMoveTime - 0.2f).SetEase(Ease.OutBounce);
    }

    /// <summary>
    /// 怪物死亡后回收view 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="value"></param>
    public void OnDead(GameEntity entity, bool value)
    {
        gameEntity.isEnable = false;
        gameEntity.isDestroyed = true;
        gameEntity.isMover = false;
    }

    public override void OnDestroyedView()
    {
        base.OnDestroyedView();
    }

}