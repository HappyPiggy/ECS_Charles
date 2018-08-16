

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