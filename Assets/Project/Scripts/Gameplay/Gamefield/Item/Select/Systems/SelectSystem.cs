using Leopotam.Ecs;

public class SelectSystem : IEcsInitSystem
{
    private readonly EcsFilter<SelectableItemComponent>.Exclude<ItemSolvedComponent> _filter;

    public void Init()
    {
        foreach (var i in _filter)
        {
            ref var selectedEvent = ref _filter.Get1(i);

            var eventTrigger = selectedEvent.EventTrigger;
            var transform = selectedEvent.Transform;

            var entity = _filter.GetEntity(i);

            foreach(var trigger in eventTrigger.triggers)
                trigger.callback.AddListener((eventData) => SendEvent(entity));

            entity.Del<SelectableItemComponent>();
        }
    }

    private void SendEvent(EcsEntity entity)
    {
        entity.Get<SelectedEvent>();
        entity.Get<SelectedComponent>();
    }
}
