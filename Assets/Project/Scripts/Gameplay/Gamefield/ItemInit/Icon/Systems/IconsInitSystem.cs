using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

public class IconsInitSystem : IEcsPreInitSystem, IEcsRunSystem
{
    private readonly EcsFilter<ItemComponent, InitIconRequest> _requestFilter;
    private readonly AvaibleIconsHolder _avaibleIcons;
    private readonly ItemInitConfig _itemInitConfig;
    private readonly EcsWorld _world;

    public void PreInit()
    {
        var icons = new List<Sprite>();

        foreach(var sprite in _itemInitConfig.Sprites)
        {
            icons.Add(sprite);
            icons.Add(sprite);
        }

        _avaibleIcons.Icons = icons;
    }

    public void Run()
    {
        foreach(var i in _requestFilter)
        {
            ref var itemComponent = ref _requestFilter.Get1(i);

            var icons = _avaibleIcons.Icons;

            var randomIndex = Random.Range(0, icons.Count);
            itemComponent.IconView.sprite = icons[randomIndex];
            itemComponent.IconView.SetNativeSize();
            icons.RemoveAt(randomIndex);
        }
    }
}