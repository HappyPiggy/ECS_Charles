

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
    Missile,
}

public enum ItemType
{
    Shield=0,//保护罩
    None=1,
}

public enum PlayerType
{
    None,
    Fly1,
    Fly2,
}

public enum EnemyState
{
    None,
    Move,
    Die,
}