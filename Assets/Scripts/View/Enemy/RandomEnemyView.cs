using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 随机敌人view
/// </summary>
public class RandomEnemyView : BaseView,IDeadListener
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
        base.Update();
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
     //   gameEntity.ReplaceEnemyState(EnemyState.Die); 
    }

    public override void OnDestroyedView()
    {
        base.OnDestroyedView();
    }




}

