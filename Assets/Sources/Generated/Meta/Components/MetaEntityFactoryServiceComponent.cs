//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity entityFactoryServiceEntity { get { return GetGroup(MetaMatcher.EntityFactoryService).GetSingleEntity(); } }
    public EntityFactoryServiceComponent entityFactoryService { get { return entityFactoryServiceEntity.entityFactoryService; } }
    public bool hasEntityFactoryService { get { return entityFactoryServiceEntity != null; } }

    public MetaEntity SetEntityFactoryService(IEntityFactoryService newInstance) {
        if (hasEntityFactoryService) {
            throw new Entitas.EntitasException("Could not set EntityFactoryService!\n" + this + " already has an entity with EntityFactoryServiceComponent!",
                "You should check if the context already has a entityFactoryServiceEntity before setting it or use context.ReplaceEntityFactoryService().");
        }
        var entity = CreateEntity();
        entity.AddEntityFactoryService(newInstance);
        return entity;
    }

    public void ReplaceEntityFactoryService(IEntityFactoryService newInstance) {
        var entity = entityFactoryServiceEntity;
        if (entity == null) {
            entity = SetEntityFactoryService(newInstance);
        } else {
            entity.ReplaceEntityFactoryService(newInstance);
        }
    }

    public void RemoveEntityFactoryService() {
        entityFactoryServiceEntity.Destroy();
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
public partial class MetaEntity {

    public EntityFactoryServiceComponent entityFactoryService { get { return (EntityFactoryServiceComponent)GetComponent(MetaComponentsLookup.EntityFactoryService); } }
    public bool hasEntityFactoryService { get { return HasComponent(MetaComponentsLookup.EntityFactoryService); } }

    public void AddEntityFactoryService(IEntityFactoryService newInstance) {
        var index = MetaComponentsLookup.EntityFactoryService;
        var component = CreateComponent<EntityFactoryServiceComponent>(index);
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceEntityFactoryService(IEntityFactoryService newInstance) {
        var index = MetaComponentsLookup.EntityFactoryService;
        var component = CreateComponent<EntityFactoryServiceComponent>(index);
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveEntityFactoryService() {
        RemoveComponent(MetaComponentsLookup.EntityFactoryService);
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
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherEntityFactoryService;

    public static Entitas.IMatcher<MetaEntity> EntityFactoryService {
        get {
            if (_matcherEntityFactoryService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.EntityFactoryService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherEntityFactoryService = matcher;
            }

            return _matcherEntityFactoryService;
        }
    }
}