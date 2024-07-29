using Leopotam.Ecs;

public abstract class SimpleWindowViewSystem<TView, TEvent> : IEcsInitSystem, IEcsRunSystem
    where TView : struct, IWindowViewComponent
    where TEvent : struct
{
    protected readonly EcsFilter<TView> ViewFilter;
    protected readonly EcsFilter<TEvent> EventFilter;

    public void Init() => TryToggle(true);
    public void Run()
    {
        if (EventFilter.GetEntitiesCount() == 0) return;
        TryToggle(false);
    }

    private void TryToggle(bool initial)
    {
        foreach (var j in ViewFilter)
        {
            ref var viewComponent = ref ViewFilter.Get1(j);
            var state = viewComponent.InitialState;

            Toggle(initial == (state == WindowViewInitialState.Enabled));
        }
    }

    private void Toggle(bool enabled)
    {
        foreach (var i in ViewFilter) ViewFilter.Get1(i).View.SetActive(enabled);
    }
}