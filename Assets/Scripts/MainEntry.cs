using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// 游戏主入口
/// </summary>
public class MainEntry:MonoSingleton<MainEntry>
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        ModuleManager.Instance.SetUp();

        //游戏系统逻辑主入口
        gameObject.AddComponent(typeof(GameController));
    }

    private void Start()
    {
        ModuleManager.Instance.Show(ModuleType.ControlPad);
    }



}
