﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.Unity;
using UnityEngine;
/// <summary>
/// view的基类
/// 链接view和entity
/// </summary>
public class BaseView : MonoBehaviour, IView
{

    public GameEntity gameEntity;
    public bool isDestroyed = false;

    public Vector2 position { get { return transform.localPosition; } }

    public Vector2 scale { get { return transform.localScale; } }

    public Quaternion rotation { get { return transform.localRotation; } }

    public ulong uid { get { return gameEntity.uID.value; } }

    public Transform objTransform { get { return transform; } }



    public void Link(IContext context, IEntity entity)
    {
        gameObject.Link(entity,context);

        gameEntity = entity as GameEntity;
    }

    protected virtual void Update()
    {
        //同步view的transform属性
        if(gameEntity!=null && gameEntity.isMover && !isDestroyed)
        {
            gameEntity.ReplacePosition(position);
            gameEntity.ReplaceRotation(rotation);
        }
    }

    public virtual void OnDestroyedView()
    {
        isDestroyed = true;
        gameEntity = null;
        DestroyUnityObject();
        
    }

    public void DestroyUnityObject()
    {
        if (gameObject != null)
        {
            gameObject.Unlink();
            Destroy(this);
            Destroy(gameObject);
        }
    }
}