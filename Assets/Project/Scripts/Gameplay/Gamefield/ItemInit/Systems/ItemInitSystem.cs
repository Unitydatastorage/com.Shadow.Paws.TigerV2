using Leopotam.Ecs;

public class ItemInitSystem : IEcsInitSystem
{
    private readonly EcsFilter<ItemComponent> _filter;
    private readonly ItemInitConfig _config;

    public void Init()
    {
        foreach(var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            entity.Get<InitIconRequest>();
        }
    }
}