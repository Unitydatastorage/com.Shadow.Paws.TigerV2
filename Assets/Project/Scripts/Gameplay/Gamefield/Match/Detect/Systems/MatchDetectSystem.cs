using Leopotam.Ecs;

public class MatchDetectSystem : IEcsRunSystem
{
    private readonly EcsFilter<ItemComponent, SelectedComponent, SelectAnimationEndedEvent>.Exclude<ItemSolvedComponent> _itemFilter;
    private readonly EcsWorld _world;

    public void Run()
    {
        foreach (var i in _itemFilter)
        {
            if (i < 1 || i % 2 == 0) continue;

            ref var firstEntity = ref _itemFilter.GetEntity(i);
            ref var secondEntity = ref _itemFilter.GetEntity(i - 1);

            ref var firstComponent = ref _itemFilter.Get1(i);
            ref var secondComponent = ref _itemFilter.Get1(i - 1);

            var firstType = firstComponent.IconView.sprite.name;
            var secondType = secondComponent.IconView.sprite.name;

            var firstTransform = firstComponent.Transform;
            var secondTransform = secondComponent.Transform;

            if (firstType != secondType)
            {
                firstEntity.Get<DeselectRequest>();
                secondEntity.Get<DeselectRequest>();
                continue;
            }

            _world.SendMessage(new MatchComponent()
            {
                First = firstTransform,
                Second = secondTransform,
            });

            firstEntity.Get<ItemSolvedComponent>();
            secondEntity.Get<ItemSolvedComponent>();
        }
    }
}