//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public OnTriggerEnterListenerComponent onTriggerEnterListener { get { return (OnTriggerEnterListenerComponent)GetComponent(GameComponentsLookup.OnTriggerEnterListener); } }
    public bool hasOnTriggerEnterListener { get { return HasComponent(GameComponentsLookup.OnTriggerEnterListener); } }

    public void AddOnTriggerEnterListener(System.Collections.Generic.List<IOnTriggerEnterListener> newValue) {
        var index = GameComponentsLookup.OnTriggerEnterListener;
        var component = CreateComponent<OnTriggerEnterListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceOnTriggerEnterListener(System.Collections.Generic.List<IOnTriggerEnterListener> newValue) {
        var index = GameComponentsLookup.OnTriggerEnterListener;
        var component = CreateComponent<OnTriggerEnterListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveOnTriggerEnterListener() {
        RemoveComponent(GameComponentsLookup.OnTriggerEnterListener);
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

    static Entitas.IMatcher<GameEntity> _matcherOnTriggerEnterListener;

    public static Entitas.IMatcher<GameEntity> OnTriggerEnterListener {
        get {
            if (_matcherOnTriggerEnterListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OnTriggerEnterListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOnTriggerEnterListener = matcher;
            }

            return _matcherOnTriggerEnterListener;
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

    public void AddOnTriggerEnterListener(IOnTriggerEnterListener value) {
        var listeners = hasOnTriggerEnterListener
            ? onTriggerEnterListener.value
            : new System.Collections.Generic.List<IOnTriggerEnterListener>();
        listeners.Add(value);
        ReplaceOnTriggerEnterListener(listeners);
    }

    public void RemoveOnTriggerEnterListener(IOnTriggerEnterListener value, bool removeComponentWhenEmpty = true) {
        var listeners = onTriggerEnterListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveOnTriggerEnterListener();
        } else {
            ReplaceOnTriggerEnterListener(listeners);
        }
    }
}
