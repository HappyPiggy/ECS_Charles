using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 模块管理
/// </summary>
public class ModuleManager:MonoSingleton<ModuleManager>
{
    private Dictionary<ModuleType, Type> uiClassNameMap; //ui面板 和ui上脚本 映射
    private Dictionary<ModuleType, AppModule> uiObjMap; //ui面板 gameobject映射

    public static Transform UIRoot;

    public  delegate void  ModuleShowOrHideHandler(bool isShow,ModuleType type);
    public static event ModuleShowOrHideHandler OnModuleShowOrHideHander;


    /// <summary>
    /// 初始化ui配置
    /// </summary>
    public void SetUp()
    {
        uiClassNameMap = new Dictionary<ModuleType, Type>();
        uiObjMap = new Dictionary<ModuleType, AppModule>();
        uiClassNameMap.Add(ModuleType.ControlPad,typeof(ControlPad)); //在ControlPad的ui上添加名为ControlPad的脚本
        uiClassNameMap.Add(ModuleType.EndGamePad, typeof(EndGamePad));

        UIRoot = GameObject.Find("Canvas/UI").transform;
    }

    /// <summary>
    /// 触发事先在别的类中注册的 
    /// module在show或hide时的逻辑
    /// </summary>
    /// <param name="isShow"></param>
    /// <param name="tp"></param>
    public static void  FireModule(bool isShow,ModuleType tp)
    {
        if (OnModuleShowOrHideHander != null)
            OnModuleShowOrHideHander(isShow,tp);
    }

    /// <summary>
    /// 外部调用显示UI
    /// </summary>
    /// <param name="type"></param>
    /// <param name="data"></param>
    public void Show(ModuleType type ,object data=null)
    {
        //如果已经加载过则存入map，再次显示时直接show
        //如果未被加载，则从资源目录加载后，再进行show
        AppModule baseUI = null;
        if (uiObjMap.ContainsKey(type))
        {
            baseUI = uiObjMap[type];
            ShowModule(baseUI,type,data);
        }
        else
        {
            StartLoad(AssetType.Module, type.ToString(), (GameObject uiObj, string uiName) =>
            {
                Type className = uiClassNameMap[type];
                uiObj.AddComponent(className);

                baseUI = uiObj.GetComponent<AppModule>();
                ShowModule(baseUI, type, data);

                uiObjMap.Add(type,baseUI);
            });
        }

    }

    /// <summary>
    /// 隐藏ui
    /// </summary>
    /// <param name="type"></param>
    public void Hide(ModuleType type)
    {
        AppModule baseUI = null;
        if (uiObjMap.ContainsKey(type))
        {
            baseUI = uiObjMap[type];
        }
        else
        {
            Debug.Log("找不到ui类型:"+type);
        }

        if (baseUI != null)
            baseUI.OnHide();
    }

    /// <summary>
    /// 隐藏所有面板
    /// </summary>
    public void HideAll()
    {
        foreach (var ui in uiObjMap)
        {
            if (ui.Value.IsHide == false)
            {
                ui.Value.OnHide();
            }
        }
    }

    private void ShowModule(AppModule baseUI,ModuleType type,object data =null)
    {
        baseUI.type = type;
        baseUI.transform.SetAsLastSibling(); //新生成的ui放在最后
        baseUI.OnShow(data);
    }

    /// <summary>
    /// 加载UI资源文件
    /// </summary>
    /// <param name="assetType"></param>
    /// <param name="name"></param>
    /// <param name="onCompeleteLoad"></param>
    private void StartLoad(AssetType assetType,string name,Action<GameObject,string> onCompeleteLoad=null)
    {
        var res = Resources.Load(AssetUtils.GetAssetFolderName(assetType)+"/"+name);

        if(res==null)
        {
            if(onCompeleteLoad!=null)
                onCompeleteLoad(null, name);
        }
        else
        {
            GameObject go = Instantiate(res) as GameObject;
            go.name = name;
            if (onCompeleteLoad != null)
                onCompeleteLoad(go,name);
        }
    }
}