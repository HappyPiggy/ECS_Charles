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
        if (gameEntity != null  && !isDestroyed)
        {

            var euler = gameEntity.rotation.value.eulerAngles.y;
            if (euler != 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, euler),10 * Time.deltaTime);
                oldEuler = transform.eulerAngles.z;
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



    public void OnDead(GameEntity entity, bool value)
    {
        gameEntity.isMover = false;
        gameEntity.isDestroyed = true;
    }


    public override void OnDestroyedView()
    {
        base.OnDestroyedView();
    }




}