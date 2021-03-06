//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public OnTriggerExitListenerComponent onTriggerExitListener { get { return (OnTriggerExitListenerComponent)GetComponent(GameComponentsLookup.OnTriggerExitListener); } }
    public bool hasOnTriggerExitListener { get { return HasComponent(GameComponentsLookup.OnTriggerExitListener); } }

    public void AddOnTriggerExitListener(System.Collections.Generic.List<IOnTriggerExitListener> newValue) {
        var index = GameComponentsLookup.OnTriggerExitListener;
        var component = CreateComponent<OnTriggerExitListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceOnTriggerExitListener(System.Collections.Generic.List<IOnTriggerExitListener> newValue) {
        var index = GameComponentsLookup.OnTriggerExitListener;
        var component = CreateComponent<OnTriggerExitListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveOnTriggerExitListener() {
        RemoveComponent(GameComponentsLookup.OnTriggerExitListener);
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

    static Entitas.IMatcher<GameEntity> _matcherOnTriggerExitListener;

    public static Entitas.IMatcher<GameEntity> OnTriggerExitListener {
        get {
            if (_matcherOnTriggerExitListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OnTriggerExitListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOnTriggerExitListener = matcher;
            }

            return _matcherOnTriggerExitListener;
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

    public void AddOnTriggerExitListener(IOnTriggerExitListener value) {
        var listeners = hasOnTriggerExitListener
            ? onTriggerExitListener.value
            : new System.Collections.Generic.List<IOnTriggerExitListener>();
        listeners.Add(value);
        ReplaceOnTriggerExitListener(listeners);
    }

    public void RemoveOnTriggerExitListener(IOnTriggerExitListener value, bool removeComponentWhenEmpty = true) {
        var listeners = onTriggerExitListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveOnTriggerExitListener();
        } else {
            ReplaceOnTriggerExitListener(listeners);
        }
    }
}
