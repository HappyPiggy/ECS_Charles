using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// 游戏中各种配置
/// </summary>
public class ConfigService
{
    public GlobalInfo globalInfo;

    public GlobalInfo GetGlobalInfo()
    {
        return globalInfo;
    }

    public PlayerInfo GetPlayerInfo()
    {
        return globalInfo.playerInfo;
    }
}