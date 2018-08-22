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

    public static float collisionDelayTime = 1; //延迟碰撞检测时间 ，延迟消失spilt时间
    public static float itemSpawnTime = 1f; //道具生成时间间隔
    public static int maxItemInGame = 3;//最多道具存在数
}