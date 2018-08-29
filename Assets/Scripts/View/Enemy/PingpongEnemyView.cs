using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// pingpong类型敌人view
/// 从屏幕最左边到屏幕最右边往复运动
/// </summary>
public class PingpongEnemyView : BaseView,IDeadListener
{
    Vector3[] path;

    public void Start()
    {
        gameEntity.AddDeadListener(this);
        gameEntity.isMover = true;
        gameEntity.isEnable = true;


      
         path = new Vector3[] {
            new Vector3(-gameEntity.position.value.x, gameEntity.position.value.y, 0)
        };

        transform.DOLocalPath(path, 2, PathType.Linear).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
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
    /// 怪物死亡后回收view 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="value"></param>
    public void OnDead(GameEntity entity, bool value)
    {
        DOTween.Kill(transform);

        gameEntity.isEnable = false;
        gameEntity.isDestroyed = true;
        gameEntity.isMover = false;
    }

    public override void OnDestroyedView()
    {
        gameEntity.RemoveDeadListener(this);
        base.OnDestroyedView();
    }
}

