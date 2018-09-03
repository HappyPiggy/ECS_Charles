using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 游戏中各种配置
/// todo:根据uid查找具体配置
/// </summary>
public class ConfigService
{
    public GlobalInfo globalInfo;

    public ConfigService()
    {
    }

    /// <summary>
    /// 初始化地图边界配置
    /// </summary>
    private void SetBorder()
    {

       //初始化border
       var up = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height-150));
        var down = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
        var left = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
        var right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width , Screen.height/2));

        globalInfo.mapInfo.border = new Border(left.x, right.x, down.y, up.y);
    }

    public GlobalInfo GetGlobalInfo()
    {
        return globalInfo;
    }

    public PlayerInfo GetPlayerInfo(ulong uid = 0)
    {
        return globalInfo.playerInfo;
    }

    public MapInfo GetMapInfo(ulong uid=0)
    {
        SetBorder();
        return globalInfo.mapInfo;
    }

    public NormalEnemyInfo GetEnemyInfo()
    {
        return globalInfo.normalEnemyInfo;
    }


    public SpiltInfo GetSpiltInfo()
    {
        return globalInfo.spiltInfo;
    }

    public ItemInfo GetItemInfo()
    {
        return globalInfo.itemInfo;
    }

    public ItemInfo GetPlayerItemInfo()
    {
        return globalInfo.playerItemInfo;
    }

}