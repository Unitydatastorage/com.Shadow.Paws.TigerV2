using Leopotam.Ecs;

public class LoadSceneButtonSystem : IEcsInitSystem
{
    private readonly EcsFilter<LoadSceneButtonComponent> _filter;
    private readonly EcsWorld _world;

    public void Init()
    {
        foreach(var i in _filter)
        {
            ref var buttonComponent = ref _filter.Get1(i);
            ref var entity = ref _filter.GetEntity(i);
            var button = buttonComponent.Button;
            var sceneName = buttonComponent.SceneName;
            button.onClick.AddListener(() => NotifyWorld(sceneName));
        }
    }

    private void NotifyWorld(string sceneName)
    {
        var sceneLoadingEvent = new LoadSceneRequest() { SceneName = sceneName };
        _world.SendMessage(sceneLoadingEvent);
    }
}