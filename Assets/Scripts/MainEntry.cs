using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 游戏主入口
/// </summary>
public class MainEntry:MonoBehaviour
{

    private static MainEntry _instance;
    public static MainEntry Instance
    {
        get
        {
           return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);

        ModuleManager.Instance.SetUp();

        //游戏系统逻辑主入口
        gameObject.AddComponent(typeof(GameController));
    }

    private void Start()
    {
    }



}
