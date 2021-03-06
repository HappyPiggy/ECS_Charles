//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ItemTypeComponent itemType { get { return (ItemTypeComponent)GetComponent(GameComponentsLookup.ItemType); } }
    public bool hasItemType { get { return HasComponent(GameComponentsLookup.ItemType); } }

    public void AddItemType(ItemType newValue, ItemType newLastType) {
        var index = GameComponentsLookup.ItemType;
        var component = CreateComponent<ItemTypeComponent>(index);
        component.value = newValue;
        component.lastType = newLastType;
        AddComponent(index, component);
    }

    public void ReplaceItemType(ItemType newValue, ItemType newLastType) {
        var index = GameComponentsLookup.ItemType;
        var component = CreateComponent<ItemTypeComponent>(index);
        component.value = newValue;
        component.lastType = newLastType;
        ReplaceComponent(index, component);
    }

    public void RemoveItemType() {
        RemoveComponent(GameComponentsLookup.ItemType);
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

    static Entitas.IMatcher<GameEntity> _matcherItemType;

    public static Entitas.IMatcher<GameEntity> ItemType {
        get {
            if (_matcherItemType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ItemType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherItemType = matcher;
            }

            return _matcherItemType;
        }
    }
}
