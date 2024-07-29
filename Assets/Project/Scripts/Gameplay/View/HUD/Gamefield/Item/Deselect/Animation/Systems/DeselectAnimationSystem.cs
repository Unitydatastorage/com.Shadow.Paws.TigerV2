using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

public class DeselectAnimationSystem : IEcsRunSystem
{
    private readonly EcsFilter<ItemComponent, DeselectedEvent> _filter;
    private readonly ItemAnimationConfig _config;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            ref var itemComponent = ref _filter.Get1(i);

            var transform = itemComponent.Transform;
            var iconView = itemComponent.IconView;

            StartAnimation(transform, () =>
            {
                iconView.gameObject.SetActive(false);
                EndAnimation(transform);
            });
        }
    }

    private void StartAnimation(Transform transform, TweenCallback callback)
    {
        transform.DOScale(0, _config.CollapseDuration).SetEase(_config.CollapseEase).OnComplete(callback);
    }

    private void EndAnimation(Transform transform)
    {
        transform.DOScale(Vector3.one, _config.AppearanceDuration).SetEase(_config.AppearanceEase);
    }
}