using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


//实例化 保存T类型的类 （泛型）
public abstract class MonoSingleton<T> : MonoBehaviour
    where T : new()
{
    private static T _instance ;

    public static T Instance
    {
        get {

            if (_instance == null)
            {
                _instance = new T() ;
            }
            return _instance;
        }
    }


}