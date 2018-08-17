//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class OnTriggerEnterEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly Entitas.IGroup<GameEntity> _listeners;

    public OnTriggerEnterEventSystem(Contexts contexts) : base(contexts.game) {
        _listeners = contexts.game.GetGroup(GameMatcher.OnTriggerEnterListener);
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.OnTriggerEnter)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasOnTriggerEnter;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.onTriggerEnter;
            foreach (var listenerEntity in _listeners) {
                foreach (var listener in listenerEntity.onTriggerEnterListener.value) {
                    listener.OnOnTriggerEnter(e, component.collision);
                }
            }
        }
    }
}
