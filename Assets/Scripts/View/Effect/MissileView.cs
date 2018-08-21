using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MissileView:BaseView
{
    private void Start()
    {
        DoScale();
        //todo 将特效消失的时间配置成player的属性 可控
        Invoke("DelayDestroy",3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyView view = collision.gameObject.GetComponent<BaseView>() as EnemyView;
            if (view != null)
            {
                view.gameEntity.ReplaceEnemyState(EnemyState.Die);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyView view = collision.gameObject.GetComponent<BaseView>() as EnemyView;
            if (view != null)
            {
                view.gameEntity.ReplaceEnemyState(EnemyState.Die);
            }
        }
    }
    private void DoScale()
    {
        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale,0.5f).SetEase(Ease.OutBounce);
    }



    private void DelayDestroy()
    {
        Destroy(gameObject);
    }

}