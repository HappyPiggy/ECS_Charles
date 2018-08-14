using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池辅助
/// </summary>
public class PoolUtil  {

    /// <summary>
    /// 对象池取出obj
    /// </summary>
    /// <param name="go"></param>
    /// <param name="pos"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static GameObject SpawnGameObject(GameObject go,Vector2 pos,Quaternion rot,Transform parent)
    {
        GameObject obj=  TrashMan.spawn(go,pos,rot);
        obj.SetActive(true);
        obj.transform.SetParent(parent);
        obj.name = go.name;
        return obj;
    }


    /// <summary>
    /// 回收obj
    /// </summary>
    /// <param name="go"></param>
    public static void DeSpawnGameObject(GameObject go)
    {
        TrashMan.despawn(go);
    }

}
