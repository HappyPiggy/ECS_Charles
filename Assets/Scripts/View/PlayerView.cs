using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 主角view
/// </summary>
public class PlayerView : BaseView,IDeadListener,IOnTriggerEnterListener
{

    private float curEuler = 0;
    private float oldEuler = 0;

    private GameObject shieldEffect;//保护罩
    private ShieldView shieldView;

    private void Start()
    {
        shieldEffect = transform.Find("shield").gameObject;
        shieldView = shieldEffect.AddComponent<ShieldView>();

        HideAllEffect();


        gameEntity.AddDeadListener(this);
        gameEntity.AddOnTriggerEnterListener(this);
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
        gameEntity.ReplaceOnTriggerEnter(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        gameEntity.ReplaceOnTriggerEnter(collision);
    }




    public void OnDead(GameEntity entity, bool value)
    {
        gameEntity.isMover = false;
        shieldView.OnDestroyedView();
        HideAllEffect();
        OnDestroyedView();
    }


    /// <summary>
    /// 隐藏所有人物特效
    /// </summary>
    private void HideAllEffect()
    {
        shieldEffect.SetActive(false);
    }

    //ecs碰撞检测的监听
    public void OnOnTriggerEnter(GameEntity entity, Collider2D collision)
    {
        //因为碰撞检测消息是广播
        //此处需要判断是不是自身的碰撞检测
        //if(entity == gameEntity)
        //{
        //    BaseView view = collision.gameObject.GetComponent<BaseView>();
        //    if (collision.gameObject.tag == "Item")
        //    {
        //        if (view.gameEntity != null)
        //        {
        //            var index = view.gameEntity.typeIndex.value;
        //            ShowEffect(index);
        //            view.gameEntity.isDestroyed = true;
        //        }
                  
        //    }
        //}
    }


    ///// <summary>
    ///// player吃道具后的特效显示
    ///// </summary>
    ///// <param name="index">道具类型</param>
    //private void ShowEffect(int index)
    //{
    //    switch (index)
    //    {
    //        case (int)ItemType.Shield:
    //            gameEntity.isInvincible=true; //生成了保护罩后 无敌
    //            shieldEffect.SetActive(true);
    //            break;

    //        default:
    //            Debug.Log("未知道具类型:"+ index);
    //            break;
    //    }
    //}
}