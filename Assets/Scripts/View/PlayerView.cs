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

            var euler = gameEntity.rotation.value.eulerAngles.y;
            if (euler != 0)
            {
                //旋转的平滑过渡
                if (curEuler < 0)
                {
                    curEuler += 360;
                    curEuler = curEuler % 360;
                }
               

                if (euler - curEuler > 180)
                {
                    euler -= 360;
                }
                else if (curEuler - euler > 180)
                {
                    euler += 360;
                }
                

                DOTween.To(() => curEuler, x => curEuler = x, euler, 0.5f);
                transform.eulerAngles = new Vector3(0, 0, curEuler);
                oldEuler = curEuler;
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