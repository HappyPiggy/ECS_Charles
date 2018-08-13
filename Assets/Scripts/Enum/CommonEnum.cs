

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
    EndGame,
}

public enum UnitType
{
    None=0,
    Player=1,
    Enemy,
    GameMap, //游戏背景
}

public enum PlayerType
{
    None,
    Fly1,
    Fly2,
}