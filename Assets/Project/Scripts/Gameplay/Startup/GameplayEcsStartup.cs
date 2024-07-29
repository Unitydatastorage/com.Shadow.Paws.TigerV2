using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class GameplayEcsStartup : MonoBehaviour
{
    [SerializeField] private ItemInitConfig _itemInitConfig;
    [SerializeField] private ItemAnimationConfig _itemAnimationConfig;

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
        _systems.
            Inject(new AvaibleIconsHolder()).
            Inject(_itemInitConfig).
            Inject(_itemAnimationConfig);
    }

    private void AddSystems()
    {
        _systems.
            Add(new TimerSystem()).
            Add(new SceneLoadingSystem()).
            Add(new LoadSceneButtonSystem()).
            Add(new IconsInitSystem()).
            Add(new ItemInitSystem()).
            Add(new SelectSystem()).
            Add(new SelectAnimationSystem()).
            Add(new MatchDetectSystem()).
            Add(new DeselectSystem()).
            Add(new DeselectAnimationSystem()).
            Add(new WinSystem()).
            Add(new HUDViewSystem()).
            Add(new WinViewSystem());
    }

    private void AddOneFrames()
    {
        _systems.
            OneFrame<InitIconRequest>().
            OneFrame<LoadSceneRequest>().
            OneFrame<SelectedEvent>().
            OneFrame<DeselectRequest>().
            OneFrame<DeselectedEvent>();
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
