using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 机关枪子弹
/// </summary>
public class BulletView : BaseView
{
    private float speed = 10;

    private void Start()
    {
        isDestroyed = false;
        Invoke("DelayDestroy", 2);
    }

    protected override void Update()
    {
        if (!isDestroyed)
        {
            var newPos = transform.position + transform.up * speed * Time.deltaTime;
            transform.position = newPos;
        }

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
            PoolUtil.DeSpawnGameObject(gameObject);
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
            PoolUtil.DeSpawnGameObject(gameObject);
        }
    }



    private void DelayDestroy()
    {
        PoolUtil.DeSpawnGameObject(gameObject);
        isDestroyed = true;
       // Destroy(this);
    }
}