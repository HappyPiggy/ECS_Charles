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
        IView view=null;
        UnitType type = entity.unitType.value;
        GameObject prefab = null;
        GameObject obj = null;
        switch (type)
        {
            //从配置中读取prefab然后实例化，将view脚本和entity链接
            case UnitType.Player:
                prefab = entity.playerInfo.value.prefab;
                obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);

                view = obj.AddComponent<PlayerView>();
                break;
            case UnitType.Enemy:
                var index = (int)entity.uID.value % (entity.enemyInfo.value.enemyList.Length);
              //  entity.enemyInfo.value.index = index;
                prefab = entity.enemyInfo.value.enemyList[index];
                obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);

                view = obj.AddComponent<EnemyView>();
                break;

            case UnitType.GameMap:
                prefab = entity.mapInfo.value.prefab;
                obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);

                view = obj.AddComponent<MapView>();
                break;

            case UnitType.Spilt:
                var index2 = MathUtils.RandomInt(0, entity.spiltInfo.value.spiltList.Length-1);
                prefab = entity.spiltInfo.value.spiltList[index2];
                obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);
                obj.GetComponent<SpriteRenderer>().color = entity.colorInfo.value.color;

                view = obj.AddComponent<SpiltView>();
                break;

            default:
                Debug.Log("无法创建预制体类型:" + type.ToString());
                break;
        }
        view.Link(context, entity);
        entity.AddView(view);
      //  entity.ReplaceUID((ulong)obj.GetInstanceID());//单机的话uid本地生成
    }

    public void Update()
    {

    }
}