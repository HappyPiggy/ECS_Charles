//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameViewListenerComponent gameViewListener { get { return (GameViewListenerComponent)GetComponent(GameComponentsLookup.GameViewListener); } }
    public bool hasGameViewListener { get { return HasComponent(GameComponentsLookup.GameViewListener); } }

    public void AddGameViewListener(System.Collections.Generic.List<IGameViewListener> newValue) {
        var index = GameComponentsLookup.GameViewListener;
        var component = CreateComponent<GameViewListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameViewListener(System.Collections.Generic.List<IGameViewListener> newValue) {
        var index = GameComponentsLookup.GameViewListener;
        var component = CreateComponent<GameViewListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameViewListener() {
        RemoveComponent(GameComponentsLookup.GameViewListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameViewListener;

    public static Entitas.IMatcher<GameEntity> GameViewListener {
        get {
            if (_matcherGameViewListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameViewListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameViewListener = matcher;
            }

            return _matcherGameViewListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddGameViewListener(IGameViewListener value) {
        var listeners = hasGameViewListener
            ? gameViewListener.value
            : new System.Collections.Generic.List<IGameViewListener>();
        listeners.Add(value);
        ReplaceGameViewListener(listeners);
    }

    public void RemoveGameViewListener(IGameViewListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameViewListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameViewListener();
        } else {
            ReplaceGameViewListener(listeners);
        }
    }
}