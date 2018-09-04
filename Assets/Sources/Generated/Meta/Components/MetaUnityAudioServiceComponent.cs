//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity unityAudioServiceEntity { get { return GetGroup(MetaMatcher.UnityAudioService).GetSingleEntity(); } }
    public UnityAudioServiceComponent unityAudioService { get { return unityAudioServiceEntity.unityAudioService; } }
    public bool hasUnityAudioService { get { return unityAudioServiceEntity != null; } }

    public MetaEntity SetUnityAudioService(UnityAudioService newInstance) {
        if (hasUnityAudioService) {
            throw new Entitas.EntitasException("Could not set UnityAudioService!\n" + this + " already has an entity with UnityAudioServiceComponent!",
                "You should check if the context already has a unityAudioServiceEntity before setting it or use context.ReplaceUnityAudioService().");
        }
        var entity = CreateEntity();
        entity.AddUnityAudioService(newInstance);
        return entity;
    }

    public void ReplaceUnityAudioService(UnityAudioService newInstance) {
        var entity = unityAudioServiceEntity;
        if (entity == null) {
            entity = SetUnityAudioService(newInstance);
        } else {
            entity.ReplaceUnityAudioService(newInstance);
        }
    }

    public void RemoveUnityAudioService() {
        unityAudioServiceEntity.Destroy();
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

    public UnityAudioServiceComponent unityAudioService { get { return (UnityAudioServiceComponent)GetComponent(MetaComponentsLookup.UnityAudioService); } }
    public bool hasUnityAudioService { get { return HasComponent(MetaComponentsLookup.UnityAudioService); } }

    public void AddUnityAudioService(UnityAudioService newInstance) {
        var index = MetaComponentsLookup.UnityAudioService;
        var component = CreateComponent<UnityAudioServiceComponent>(index);
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceUnityAudioService(UnityAudioService newInstance) {
        var index = MetaComponentsLookup.UnityAudioService;
        var component = CreateComponent<UnityAudioServiceComponent>(index);
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveUnityAudioService() {
        RemoveComponent(MetaComponentsLookup.UnityAudioService);
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

    static Entitas.IMatcher<MetaEntity> _matcherUnityAudioService;

    public static Entitas.IMatcher<MetaEntity> UnityAudioService {
        get {
            if (_matcherUnityAudioService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.UnityAudioService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherUnityAudioService = matcher;
            }

            return _matcherUnityAudioService;
        }
    }
}
