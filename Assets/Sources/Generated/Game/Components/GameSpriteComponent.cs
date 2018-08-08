//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SpriteComponent sprite { get { return (SpriteComponent)GetComponent(GameComponentsLookup.Sprite); } }
    public bool hasSprite { get { return HasComponent(GameComponentsLookup.Sprite); } }

    public void AddSprite(string newName) {
        var index = GameComponentsLookup.Sprite;
        var component = CreateComponent<SpriteComponent>(index);
        component.name = newName;
        AddComponent(index, component);
    }

    public void ReplaceSprite(string newName) {
        var index = GameComponentsLookup.Sprite;
        var component = CreateComponent<SpriteComponent>(index);
        component.name = newName;
        ReplaceComponent(index, component);
    }

    public void RemoveSprite() {
        RemoveComponent(GameComponentsLookup.Sprite);
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

    static Entitas.IMatcher<GameEntity> _matcherSprite;

    public static Entitas.IMatcher<GameEntity> Sprite {
        get {
            if (_matcherSprite == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Sprite);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSprite = matcher;
            }

            return _matcherSprite;
        }
    }
}
