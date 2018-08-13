//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly OnTriggerExitComponent onTriggerExitComponent = new OnTriggerExitComponent();

    public bool isOnTriggerExit {
        get { return HasComponent(GameComponentsLookup.OnTriggerExit); }
        set {
            if (value != isOnTriggerExit) {
                var index = GameComponentsLookup.OnTriggerExit;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : onTriggerExitComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherOnTriggerExit;

    public static Entitas.IMatcher<GameEntity> OnTriggerExit {
        get {
            if (_matcherOnTriggerExit == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OnTriggerExit);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOnTriggerExit = matcher;
            }

            return _matcherOnTriggerExit;
        }
    }
}
