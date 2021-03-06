﻿

public enum AssetType
{
    None,
    Module,
    Sound,
    Effect,
    Conf
}

public enum GameProgressState
{
    None,
    ParseConfig,
    StartGame,
    InGame,
    GameOver,//玩家死亡
    EndGame,//结算界面
    GameRestart,
}

public enum GameDifficulty
{
    None=0,
    Easy=1,
    Normal=2,
    Difficult,
}

public enum UnitType
{
    None=0,
    Player=1,
    Enemy,
    Spilt, //怪物死后效果
    GameMap, //游戏背景
    Item,//游戏道具
    PlayerItem,//玩家身上道具
}

public enum EffectType
{
    Missile,//护盾破后的特效
}

public enum ItemType
{
    Shield=0,//保护罩
    MachineGun=1,//机关枪
    None=2,
}

public enum PlayerType
{
    None,
    Fly1,
    Fly2,
}

//public enum EnemyBehavior
//{
//    None,
//    Normal,
//    Flee,//反向速度
//}



public enum EnemyState
{
    None,
    Move,
    Die,
}

public enum EnemyType
{
    NormalBehavior, //普通敌人
    PingpongBehavior, //来回运动的敌人
    AimBehavior,//瞄准主角的敌人
    CustomizedBehavior,//预制体中自定义的 
}

public enum NormalBehavior
{
    None,
    Chase,//追击player
    Flee,//逃离player
}

public enum PingpongBehavior
{
    None,
    Horizontal,//横向pingpong
    Vertical,//纵向pingpong
}




//怪物具体的移动方式
public  class EnemyBehavior
{
   public  NormalBehavior normalBehavior = NormalBehavior.None;
   public  PingpongBehavior pingpongBehavior = PingpongBehavior.None;
}