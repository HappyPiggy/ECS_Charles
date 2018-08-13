//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MapInfoComponent mapInfo { get { return (MapInfoComponent)GetComponent(GameComponentsLookup.MapInfo); } }
    public bool hasMapInfo { get { return HasComponent(GameComponentsLookup.MapInfo); } }

    public void AddMapInfo(MapInfo newValue) {
        var index = GameComponentsLookup.MapInfo;
        var component = CreateComponent<MapInfoComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMapInfo(MapInfo newValue) {
        var index = GameComponentsLookup.MapInfo;
        var component = CreateComponent<MapInfoComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMapInfo() {
        RemoveComponent(GameComponentsLookup.MapInfo);
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

    static Entitas.IMatcher<GameEntity> _matcherMapInfo;

    public static Entitas.IMatcher<GameEntity> MapInfo {
        get {
            if (_matcherMapInfo == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MapInfo);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMapInfo = matcher;
            }

            return _matcherMapInfo;
        }
    }
}
