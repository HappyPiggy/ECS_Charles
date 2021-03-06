//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UnitTypeComponent unitType { get { return (UnitTypeComponent)GetComponent(GameComponentsLookup.UnitType); } }
    public bool hasUnitType { get { return HasComponent(GameComponentsLookup.UnitType); } }

    public void AddUnitType(UnitType newValue) {
        var index = GameComponentsLookup.UnitType;
        var component = CreateComponent<UnitTypeComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUnitType(UnitType newValue) {
        var index = GameComponentsLookup.UnitType;
        var component = CreateComponent<UnitTypeComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUnitType() {
        RemoveComponent(GameComponentsLookup.UnitType);
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

    static Entitas.IMatcher<GameEntity> _matcherUnitType;

    public static Entitas.IMatcher<GameEntity> UnitType {
        get {
            if (_matcherUnitType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UnitType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUnitType = matcher;
            }

            return _matcherUnitType;
        }
    }
}
