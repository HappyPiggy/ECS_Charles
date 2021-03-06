//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameDifficultyEntity { get { return GetGroup(GameMatcher.GameDifficulty).GetSingleEntity(); } }
    public GameDifficultyComponent gameDifficulty { get { return gameDifficultyEntity.gameDifficulty; } }
    public bool hasGameDifficulty { get { return gameDifficultyEntity != null; } }

    public GameEntity SetGameDifficulty(GameDifficulty newState) {
        if (hasGameDifficulty) {
            throw new Entitas.EntitasException("Could not set GameDifficulty!\n" + this + " already has an entity with GameDifficultyComponent!",
                "You should check if the context already has a gameDifficultyEntity before setting it or use context.ReplaceGameDifficulty().");
        }
        var entity = CreateEntity();
        entity.AddGameDifficulty(newState);
        return entity;
    }

    public void ReplaceGameDifficulty(GameDifficulty newState) {
        var entity = gameDifficultyEntity;
        if (entity == null) {
            entity = SetGameDifficulty(newState);
        } else {
            entity.ReplaceGameDifficulty(newState);
        }
    }

    public void RemoveGameDifficulty() {
        gameDifficultyEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameDifficultyComponent gameDifficulty { get { return (GameDifficultyComponent)GetComponent(GameComponentsLookup.GameDifficulty); } }
    public bool hasGameDifficulty { get { return HasComponent(GameComponentsLookup.GameDifficulty); } }

    public void AddGameDifficulty(GameDifficulty newState) {
        var index = GameComponentsLookup.GameDifficulty;
        var component = CreateComponent<GameDifficultyComponent>(index);
        component.state = newState;
        AddComponent(index, component);
    }

    public void ReplaceGameDifficulty(GameDifficulty newState) {
        var index = GameComponentsLookup.GameDifficulty;
        var component = CreateComponent<GameDifficultyComponent>(index);
        component.state = newState;
        ReplaceComponent(index, component);
    }

    public void RemoveGameDifficulty() {
        RemoveComponent(GameComponentsLookup.GameDifficulty);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameDifficulty;

    public static Entitas.IMatcher<GameEntity> GameDifficulty {
        get {
            if (_matcherGameDifficulty == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameDifficulty);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameDifficulty = matcher;
            }

            return _matcherGameDifficulty;
        }
    }
}
