﻿using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;
/// <summary>
/// 保护罩view
/// </summary>
public class ShieldView:BaseView,IGameDestroyedListener
{

    private float delayTime = 0.5f;


    private void Start()
    {
        gameEntity.AddGameDestroyedListener(this);
        DoScale();

    }



    protected override void Update()
    {
        transform.localPosition = gameEntity.position.value;
    }

    private void DoScale()
    {
        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale, delayTime).SetEase(Ease.OutBounce);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public override void OnDestroyedView()
    {
        base.OnDestroyedView();
    }

    public void OnDestroyed(GameEntity entity)
    {
        OnDestroyedView();
        //Debug.Log("OnDestroyed");
    }
}