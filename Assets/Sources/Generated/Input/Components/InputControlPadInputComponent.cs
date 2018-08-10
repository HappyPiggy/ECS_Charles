//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity controlPadInputEntity { get { return GetGroup(InputMatcher.ControlPadInput).GetSingleEntity(); } }

    public bool isControlPadInput {
        get { return controlPadInputEntity != null; }
        set {
            var entity = controlPadInputEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isControlPadInput = true;
                } else {
                    entity.Destroy();
                }
            }
        }
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
public partial class InputEntity {

    static readonly ControlPadInputComponent controlPadInputComponent = new ControlPadInputComponent();

    public bool isControlPadInput {
        get { return HasComponent(InputComponentsLookup.ControlPadInput); }
        set {
            if (value != isControlPadInput) {
                var index = InputComponentsLookup.ControlPadInput;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : controlPadInputComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherControlPadInput;

    public static Entitas.IMatcher<InputEntity> ControlPadInput {
        get {
            if (_matcherControlPadInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ControlPadInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherControlPadInput = matcher;
            }

            return _matcherControlPadInput;
        }
    }
}
