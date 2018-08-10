using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 加载游戏中各种资源
/// gameobject与entity的link
/// </summary>
public class UnityViewService : IAssetListener, IViewService
{
    private GameEntity gameEntity;
    private GameContext context;

    private Transform viewObjectRoot;

    public UnityViewService(Contexts contexts)
    {
        context = contexts.game;
        gameEntity = context.CreateEntity();

        gameEntity.AddAssetListener(this);
    }

    public void OnAsset(GameEntity entity, string value)
    {

        //创建所有view的根目录
        if (viewObjectRoot == null)
        {
            GameObject go = null;
            go = GameObject.Find("Game");
            if (go == null)
            {
                go = new GameObject("Game");
            }

            viewObjectRoot = go.transform;
            GameObject.DontDestroyOnLoad(viewObjectRoot);
        }

        //根据entity中的asset类型来创建prefab
        IView view;
        UnitType type = entity.unitType.value;
        GameObject prefab = null;
        GameObject obj = null;
        switch (type)
        {
            //从配置中读取prefab然后实例化，将view脚本和entity链接
            case UnitType.Player:
                prefab = entity.playerInfo.value.prefab;
                obj = GameObject.Instantiate(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);
                view = obj.AddComponent<PlayerView>();

                view.Link(context, entity);
                entity.AddView(view);

                break;
            case UnitType.Enemy:
                break;

            default:
                Debug.Log("无法创建预制体类型:" + type.ToString());
                break;
        }
    }

    public void Update()
    {

    }
}