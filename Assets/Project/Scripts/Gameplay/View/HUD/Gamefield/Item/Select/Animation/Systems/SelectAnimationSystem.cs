using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

public class SelectAnimationSystem : IEcsRunSystem
{
    private readonly EcsFilter<ItemComponent, SelectedEvent>.Exclude<ItemSolvedComponent> _filter;
    private readonly ItemAnimationConfig _config;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            ref var itemComponent = ref _filter.Get1(i);

            var transform = itemComponent.Transform;
            var iconView = itemComponent.IconView;
            var icon = itemComponent.IconView;

            var entityCopy = entity;

            StartAnimation(transform, () =>
            {
                iconView.gameObject.SetActive(true);
                EndAnimation(transform, () => entityCopy.Get<SelectAnimationEndedEvent>());
            });
        }
    }

    private void StartAnimation(Transform transform, TweenCallback callback)
    {
        transform.DOScale(0, _config.CollapseDuration).SetEase(_config.CollapseEase).OnComplete(callback);
    }

    private void EndAnimation(Transform transform, TweenCallback callback)
    {
        transform.DOScale(Vector3.one, _config.AppearanceDuration).SetEase(_config.AppearanceEase).OnComplete(callback);
    }
}