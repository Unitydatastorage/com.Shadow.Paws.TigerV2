using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class EntryEcsStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();

        AddInjects();
        AddSystems();
        AddOneFrames();

        _systems.Init();
    }

    private void AddInjects()
    {

    }

    private void AddSystems()
    {
        _systems.
            Add(new SceneLoadingSystem()).
            Add(new SceneLoadingProgressViewSystem());
    }

    private void AddOneFrames()
    {
        _systems.
            OneFrame<LoadSceneRequest>();
    }

    private void Update() => _systems.Run();

    private void OnDestroy()
    {
        _systems.Destroy();
        _systems = null;

        _world.Destroy();
        _world = null;
    }
}
