using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///  敌人死亡后涂鸦的view
/// </summary>
public class SpiltView : BaseView,IGameDestroyedListener
{
    private Color color;
    private float alpha = 255;

    private float delayTime = 0.5f;
    private bool isHide = false;

    public void Start()
    {
        gameEntity.AddGameDestroyedListener(this);

        delayTime = ConstantUtils.delayTime;
        DoScale();
        Invoke("DelayHide", delayTime);
    }



    protected override void Update()
    {
        base.Update();

        if(isHide)
        {
            float a = alpha / 255;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, a);

            if (a == 0)
            {
                gameEntity.isDestroyed = true;
            }
        }



    }

    private void DoScale()
    {
        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale, delayTime-0.2f).SetEase(Ease.OutBounce);
    }

    /// <summary>
    /// 渐变消失
    /// </summary>
    private void DelayHide()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
        DOTween.To(() => alpha, x => alpha = x, 0, delayTime );
        isHide = true;
    }

    public void OnDestroyed(GameEntity entity)
    {
        OnDestroyedView();
    }
}

