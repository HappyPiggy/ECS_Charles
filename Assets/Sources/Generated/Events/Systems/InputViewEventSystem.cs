//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputViewEventSystem : Entitas.ReactiveSystem<InputEntity> {

    public InputViewEventSystem(Contexts contexts) : base(contexts.input) {
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(InputMatcher.View)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasView && entity.hasInputViewListener;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            var component = e.view;
            foreach (var listener in e.inputViewListener.value) {
                listener.OnView(e, component.instance);
            }
        }
    }
}
