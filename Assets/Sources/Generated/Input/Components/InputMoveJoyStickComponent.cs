//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public MoveJoyStickComponent moveJoyStick { get { return (MoveJoyStickComponent)GetComponent(InputComponentsLookup.MoveJoyStick); } }
    public bool hasMoveJoyStick { get { return HasComponent(InputComponentsLookup.MoveJoyStick); } }

    public void AddMoveJoyStick(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.MoveJoyStick;
        var component = CreateComponent<MoveJoyStickComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMoveJoyStick(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.MoveJoyStick;
        var component = CreateComponent<MoveJoyStickComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMoveJoyStick() {
        RemoveComponent(InputComponentsLookup.MoveJoyStick);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherMoveJoyStick;

    public static Entitas.IMatcher<InputEntity> MoveJoyStick {
        get {
            if (_matcherMoveJoyStick == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.MoveJoyStick);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherMoveJoyStick = matcher;
            }

            return _matcherMoveJoyStick;
        }
    }
}
