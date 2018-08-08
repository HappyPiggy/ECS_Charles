//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameProgressEntity { get { return GetGroup(GameMatcher.GameProgress).GetSingleEntity(); } }
    public GameProgressComponent gameProgress { get { return gameProgressEntity.gameProgress; } }
    public bool hasGameProgress { get { return gameProgressEntity != null; } }

    public GameEntity SetGameProgress(GameProgressState newState) {
        if (hasGameProgress) {
            throw new Entitas.EntitasException("Could not set GameProgress!\n" + this + " already has an entity with GameProgressComponent!",
                "You should check if the context already has a gameProgressEntity before setting it or use context.ReplaceGameProgress().");
        }
        var entity = CreateEntity();
        entity.AddGameProgress(newState);
        return entity;
    }

    public void ReplaceGameProgress(GameProgressState newState) {
        var entity = gameProgressEntity;
        if (entity == null) {
            entity = SetGameProgress(newState);
        } else {
            entity.ReplaceGameProgress(newState);
        }
    }

    public void RemoveGameProgress() {
        gameProgressEntity.Destroy();
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

    public GameProgressComponent gameProgress { get { return (GameProgressComponent)GetComponent(GameComponentsLookup.GameProgress); } }
    public bool hasGameProgress { get { return HasComponent(GameComponentsLookup.GameProgress); } }

    public void AddGameProgress(GameProgressState newState) {
        var index = GameComponentsLookup.GameProgress;
        var component = CreateComponent<GameProgressComponent>(index);
        component.state = newState;
        AddComponent(index, component);
    }

    public void ReplaceGameProgress(GameProgressState newState) {
        var index = GameComponentsLookup.GameProgress;
        var component = CreateComponent<GameProgressComponent>(index);
        component.state = newState;
        ReplaceComponent(index, component);
    }

    public void RemoveGameProgress() {
        RemoveComponent(GameComponentsLookup.GameProgress);
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

    static Entitas.IMatcher<GameEntity> _matcherGameProgress;

    public static Entitas.IMatcher<GameEntity> GameProgress {
        get {
            if (_matcherGameProgress == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameProgress);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameProgress = matcher;
            }

            return _matcherGameProgress;
        }
    }
}
