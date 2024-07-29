using Leopotam.Ecs;

public class WinSystem : IEcsRunSystem
{
    private readonly EcsFilter<ItemSolvedComponent> _filter;
    private readonly EcsWorld _world;

    public void Run()
    {
        if (_filter.GetEntitiesCount() < 12) return;

        foreach(var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            entity.Del<ItemSolvedComponent>();
        }

        _world.SendMessage(new WinEvent());
        _world.SendMessage(new WinComponent());
    }
}