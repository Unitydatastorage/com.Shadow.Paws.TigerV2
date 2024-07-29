using Leopotam.Ecs;
using UnityEngine;

public class ExitButtonSystem : IEcsInitSystem
{
    private readonly EcsFilter<ExitButtonComponent> _filter;

    public void Init()
    {
        foreach(var i in _filter)
        {
            ref var buttonComponent = ref _filter.Get1(i);
            var button = buttonComponent.Button;
            button.onClick.AddListener(Exit);
        }
    }

    private void Exit() => Application.Quit();
}