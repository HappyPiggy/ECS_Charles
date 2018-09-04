using System.Collections.Generic;
using UnityEngine;

public class ConstantUtils
{
    public static List<Color> spiltColorList = new List<Color>() {
                                              new Color((float)211/255,(float)187/255,1),
                                              new Color((float)195/255,(float)131/255,(float)188/255),
                                              new Color((float)68/255,(float)138/255,(float)202/255),
                                              new Color((float)153/255,(float)211/255,(float)79/255),
                                              new Color((float)161/255,(float)145/255,(float)138/255),
                                              new Color((float)234/255,(float)95/255,(float)216/255)};

    public static float EnemyDelayMoveTime = 1; //敌人延迟移动
    public static float itemSpawnTime = 1f; //道具生成时间间隔
    public static int maxItemInGame = 3;//最多道具存在数
    public static float itemDuration = 3;//道具效果持续时间

    public static float invincibleTime = 0.2f;//护盾破裂后无敌持续时间

    //定义存档路径
    public static string dirpath = Application.persistentDataPath + "/Save";
    public static string filename = dirpath + "/GameData.sav";

    public static bool isStartSpawnPingpong = false;//开始生成pingpong敌人
    public static bool isDestroySpawnPingpong = false;//销毁pingpong敌人


    public static bool isFreeMode = true;//摇杆是否为自由模式
    public static bool isGM = false;//进入无敌gm模式


}