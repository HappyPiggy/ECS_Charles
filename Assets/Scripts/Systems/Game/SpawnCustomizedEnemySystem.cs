using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生成预制体中自定义的敌人
/// </summary>
public class SpawnCustomizedEnemySystem : IExecuteSystem
{
    private Contexts contexts;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;
    private GameEntity heroEntity;

    private List<GameObject> customizedParentList;
    private Transform viewObjectRoot;
    private float timer = 1;



    public SpawnCustomizedEnemySystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.entityFactoryService = services.entityFactoryService as EntityFactoryService;
        this.configService = services.configService;

        viewObjectRoot = GameObject.Find("Game").transform;

        customizedParentList = new List<GameObject>();
    }




    public void Execute()
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            CheckDestroy();
            //timer += Time.deltaTime;
            if (timer > 0)
            {
                timer = -1;
                SpawnSpinEnemy();
            }
        }else if (contexts.game.gameProgress.state == GameProgressState.GameRestart)
        {
            CleanData();
            timer = 1;
        }
    }


    /// <summary>
    /// 清除所有数据
    /// </summary>
    private void CleanData()
    {
        for (int i = 0; i < customizedParentList.Count; i++)
        {
            if (customizedParentList[i]!=null)
            {
                GameObject.Destroy(customizedParentList[i]);
            }
        }
        customizedParentList.Clear();
    }

    /// <summary>
    /// 检查list中是否所有entity为空 是则回收父物体
    /// </summary>
    private void CheckDestroy()
    {
        var idx = -1;
        for (int i = 0; i < customizedParentList.Count; i++)
        {
            if (customizedParentList[i].transform.childCount==0)
            {
                idx = i;
                GameObject.Destroy(customizedParentList[i]);
                break;
            }
        }

        if(idx!=-1)
            customizedParentList.RemoveAt(idx);
    }


    /// <summary>
    /// 生成自转类型enemy
    /// </summary>
    private void SpawnSpinEnemy()
    {
        GameObject go=  LoadRes("spin");
        customizedParentList.Add(go);

        for (int i = 0; i < go.transform.childCount; i++)
        {
            var enemy = go.transform.GetChild(i).gameObject;
            entityFactoryService.CreateCustomizedEnemy(UidUtils.Uid, enemy.transform.position, EnemyType.CustomizedBehavior,enemy);
        }
     
    }


    /// <summary>
    /// 加载敌人prefab
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private GameObject LoadRes(string name)
    {
        var path = "Unit/Enemy/Customized/" + name;
        var res = Resources.Load(path);
        GameObject go = PoolUtil.SpawnGameObject((GameObject)res, Vector3.zero, Quaternion.identity, viewObjectRoot);
        go.name = res.name;
        return go;
    }


}
