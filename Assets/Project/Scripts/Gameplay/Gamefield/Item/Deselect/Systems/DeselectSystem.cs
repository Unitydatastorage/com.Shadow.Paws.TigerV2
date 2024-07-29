using Leopotam.Ecs;
using UnityEngine;

public class DeselectSystem : IEcsRunSystem
{
    private readonly EcsFilter<DeselectRequest, SelectedComponent> _deselectFilter;

    public void Run()
    {
        foreach(var i in _deselectFilter)
        {
            ref var entity = ref _deselectFilter.GetEntity(i);
            entity.Get<DeselectedEvent>();
            entity.Del<SelectedComponent>();
            entity.Del<SelectAnimationEndedEvent>();
        }
    }
}