using Leopotam.Ecs;

public class SceneLoadingProgressViewSystem : IEcsRunSystem
{
    private readonly EcsFilter<SceneLoadingProgressComponent> _progressFilter;
    private readonly EcsFilter<SceneLoadingViewComponent> _barsFilter;

    public void Run()
    {
        foreach(var i in _progressFilter)
        {
            ref var progressComponent = ref _progressFilter.Get1(i);

            foreach(var j in _barsFilter)
            {
                ref var barComponent = ref _barsFilter.Get1(i);
                barComponent.Bar.value = progressComponent.Progress;
            }
        }
    }
}