//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public EnemyInfoComponent enemyInfo { get { return (EnemyInfoComponent)GetComponent(GameComponentsLookup.EnemyInfo); } }
    public bool hasEnemyInfo { get { return HasComponent(GameComponentsLookup.EnemyInfo); } }

    public void AddEnemyInfo(EnemyInfo newValue) {
        var index = GameComponentsLookup.EnemyInfo;
        var component = CreateComponent<EnemyInfoComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEnemyInfo(EnemyInfo newValue) {
        var index = GameComponentsLookup.EnemyInfo;
        var component = CreateComponent<EnemyInfoComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEnemyInfo() {
        RemoveComponent(GameComponentsLookup.EnemyInfo);
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

    static Entitas.IMatcher<GameEntity> _matcherEnemyInfo;

    public static Entitas.IMatcher<GameEntity> EnemyInfo {
        get {
            if (_matcherEnemyInfo == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnemyInfo);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnemyInfo = matcher;
            }

            return _matcherEnemyInfo;
        }
    }
}
