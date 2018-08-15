using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 敌人view
/// </summary>
public class EnemyView : BaseView,IDeadListener
{

    private float delayTime = 0.8f; //延迟移动时间



    public void Start()
    {
        // color = gameObject.GetComponent<SpriteRenderer>().color;
        // DOTween.To(() => alpha, x => alpha = x, 255, delayTime-0.2f);

        DoScale();
        Invoke("DelayMove", delayTime);

        gameEntity.AddDeadListener(this);
        gameEntity.isEnable = true;
    }

   

    protected override void Update()
    {
        base.Update();

        //渐变显示敌人
     //   float a = (float)alpha / 255;
     //   gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r,color.g,color.b,a);
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
        transform.DOScale(curScale, delayTime - 0.2f).SetEase(Ease.OutBounce);
    }

    /// <summary>
    /// 怪物死亡后回收view 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="value"></param>
    public void OnDead(GameEntity entity, bool value)
    {
        gameEntity.isEnable = false;
        OnDestroyedView();
    }




}

