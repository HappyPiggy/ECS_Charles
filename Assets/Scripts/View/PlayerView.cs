using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 主角view
/// </summary>
public class PlayerView : BaseView,IDeadListener
{
  //  private float oldEuler = 0;
    private float curEuler = 0;
    private float oldEuler = 0;

    private void Start()
    {
        gameEntity.AddDeadListener(this);
    }




    protected override void Update()
    {
        base.Update();


        PlayerMove();
    }


    /// <summary>
    /// player移动和旋转
    /// </summary>
    private void PlayerMove()
    {
        if (gameEntity != null && gameEntity.isMover && !isDestroyed)
        {

            var euler = -gameEntity.rotation.value.eulerAngles.y;
            if (euler != 0)
            {
                //todo
                //旋转的平滑过渡
                // DOTween.To(() => curEuler, x => curEuler = x, euler, 2);
                transform.eulerAngles = new Vector3(0, 0, euler);
                oldEuler = euler;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, oldEuler);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Enemy":
                gameEntity.ReplaceDead(true);
                break;

        }
    }


    public void OnDead(GameEntity entity, bool value)
    {
        gameEntity.isMover = false;
        OnDestroyedView();
    }
}