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



    //unity 碰撞检测接口
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //开启无敌 防止人物移动速度过快导致立即死亡
        if (collision.gameObject.name == "shield")
        {
            gameEntity.isInvincible = true;
        }

        if (collision.gameObject.tag == "Effect")
        {
            return;
        }
        
        if (collision.gameObject.tag != "PlayerItem")
        {
            gameEntity.ReplaceOnTriggerEnter(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //开启无敌 防止人物移动速度过快导致立即死亡
        if (collision.gameObject.name == "shield")
        {
            gameEntity.isInvincible = true;
        }

        if (collision.gameObject.tag == "Effect")
        {
            return;
        }

        if (collision.gameObject.tag != "PlayerItem")
        {
            gameEntity.ReplaceOnTriggerEnter(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Missile")
        {
            gameEntity.isInvincible = false;
        }
    }




    public void OnDead(GameEntity entity, bool value)
    {
        gameEntity.isMover = false;
        OnDestroyedView();
    }





}