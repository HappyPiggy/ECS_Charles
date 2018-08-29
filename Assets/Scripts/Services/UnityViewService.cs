using DG.Tweening;
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
    }

    public void OnAsset(GameEntity entity, string value)
    {


        //根据entity中的asset类型来创建prefab
        int index = -1;
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
                if (context.gameProgress.state == GameProgressState.InGame)
                {
                    index = (int)entity.uID.value % (entity.enemyInfo.value.enemyList.Length);
                    entity.AddColorType(index);
                    prefab = entity.enemyInfo.value.enemyList[index];
                    obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);

                    var enemyType = entity.enemyType.value;
                    //不同类型的敌人
                    switch (enemyType)
                    {
                        case EnemyType.Random:
                            view = obj.AddComponent<RandomEnemyView>();
                            break;
                        case EnemyType.Pingpong:
                            view = obj.AddComponent<PingpongEnemyView>();
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    entity.isDestroyed = true;
                }
                break;

            case UnitType.GameMap:
                prefab = entity.mapInfo.value.prefab;
                obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);

                view = obj.AddComponent<MapView>();
                break;

            case UnitType.Spilt:
                index = MathUtils.RandomInt(0, entity.spiltInfo.value.spiltList.Length-1);
                prefab = entity.spiltInfo.value.spiltList[index];
                obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);
                obj.GetComponent<SpriteRenderer>().color = ConstantUtils.spiltColorList[entity.colorType.value];

                view = obj.AddComponent<SpiltView>();
                break;

            case UnitType.Item:
                index = (int)entity.itemType.value;
                prefab = entity.itemInfo.value.itemList[index];
                obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);

                view = obj.AddComponent<ItemView>();
                break;
            case UnitType.PlayerItem:
                index =(int) entity.itemType.value;
                prefab = entity.itemInfo.value.itemList[index];
                obj = PoolUtil.SpawnGameObject(prefab, entity.position.value, entity.rotation.value, viewObjectRoot);

                view = obj.GetComponent<BaseView>();  //预先在人物item的gameobjct上挂好脚本
                break;

            default:
                Debug.Log("无法创建预制体类型:" + type.ToString());
                break;
        }
        if (view != null)
        {
            view.Link(context, entity);
            entity.AddView(view);
        }
    }



    public void Update()
    {

    }
}