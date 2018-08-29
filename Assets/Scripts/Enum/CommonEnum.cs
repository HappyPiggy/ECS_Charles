

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

public enum EnemyBehavior
{
    None,
    Normal,
    Flee,//反向速度
}

public enum EnemyType
{
    Random, //随机位置 跟随player
    Pingpong, //固定位置来回移动
}

public enum EnemyState
{
    None,
    Move,
    Die,
}