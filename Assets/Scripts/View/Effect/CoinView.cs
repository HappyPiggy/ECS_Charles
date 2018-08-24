using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 敌人死亡金币特效
/// </summary>
public class CoinView:BaseView
{
    private float speed = 1;

    private void Start()
    {
        Invoke("DelayDestroy", 1);
    }

    protected override void Update()
    {
        var newPos = transform.position + transform.up * speed * Time.deltaTime;
        transform.position = newPos;
    }


    private void DelayDestroy()
    {
        Destroy(this);
        PoolUtil.DeSpawnGameObject(gameObject);
    }
}