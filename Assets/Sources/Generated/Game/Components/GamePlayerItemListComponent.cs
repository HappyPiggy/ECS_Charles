//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PlayerItemListComponent playerItemList { get { return (PlayerItemListComponent)GetComponent(GameComponentsLookup.PlayerItemList); } }
    public bool hasPlayerItemList { get { return HasComponent(GameComponentsLookup.PlayerItemList); } }

    public void AddPlayerItemList(System.Collections.Generic.List<ItemType> newValue) {
        var index = GameComponentsLookup.PlayerItemList;
        var component = CreateComponent<PlayerItemListComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerItemList(System.Collections.Generic.List<ItemType> newValue) {
        var index = GameComponentsLookup.PlayerItemList;
        var component = CreateComponent<PlayerItemListComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerItemList() {
        RemoveComponent(GameComponentsLookup.PlayerItemList);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayerItemList;

    public static Entitas.IMatcher<GameEntity> PlayerItemList {
        get {
            if (_matcherPlayerItemList == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerItemList);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerItemList = matcher;
            }

            return _matcherPlayerItemList;
        }
    }
}
