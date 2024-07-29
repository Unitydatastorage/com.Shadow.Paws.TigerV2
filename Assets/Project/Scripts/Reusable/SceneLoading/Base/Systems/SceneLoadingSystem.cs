using Leopotam.Ecs;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneLoadingSystem : IEcsRunSystem
{
    private readonly EcsFilter<LoadSceneRequest> _filter;
    private readonly EcsWorld _world;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref var loadingEvent = ref _filter.Get1(i);
            var sceneName = loadingEvent.SceneName;

            LoadScene(sceneName);
        }
    }

    private async void LoadScene(string sceneName)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        var entity = _world.NewEntity();
        entity.Get<SceneLoadingEvent>().SceneName = sceneName;

        while (!asyncOperation.isDone)
        {
            var progress = asyncOperation.progress;
            NotifyWorld(ref entity, progress);

            await Task.Yield();

            if (progress >= 0.9f) asyncOperation.allowSceneActivation = true;
        }

        DataHolder.LastSceneName = sceneName;
    }

    private void NotifyWorld(ref EcsEntity entity, float progress)
    {
        if (entity.IsNull() || !entity.IsAlive()) return;
        entity.Get<SceneLoadingProgressComponent>().Progress = progress;
    }
}