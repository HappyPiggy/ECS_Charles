using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// ui界面的基类
/// </summary>
public class AppModule:MonoBehaviour
{
    [HideInInspector]
    public ModuleType type = ModuleType.UI_NONE;

    protected object data;


    private bool isHide=true;
    private bool isNeedCache = false;

    public bool IsHide
    {
        get
        {
            return isHide;
        }

        set
        {
            isHide = value;
        }
    }

    public bool IsNeedCache
    {
        get
        {
            return isNeedCache;
        }

        set
        {
            isNeedCache = value;
        }
    }

    private void Awake()
    {
        OnAwake();
    }

    private void Update()
    {
        OnUpdate();
    }

    private void Start()
    {
        OnStart();
    }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }


    public virtual void OnShow(object data =null)
    {
        IsHide = false;
        this.data = data;
        transform.SetParent(ModuleManager.UIRoot,false);
        gameObject.SetActive(true);
        ModuleManager.FireModule(true,type);
    }

    public virtual void OnHide()
    {
        IsHide = true;
        gameObject.SetActive(false);
        ModuleManager.FireModule(false, type);
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

}