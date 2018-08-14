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
public class EnemyView : BaseView
{
    private int alpha = 0;
    private Color color;
    public void Start()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
        DOTween.To(() => alpha, x => alpha = x, 255, 1);
        
    }

    protected override void Update()
    {
        base.Update();

        float a = (float)alpha / 255;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r,color.g,color.b,a);
    }
}

