using Leopotam.Ecs;

public static class WorldExtentions
{
    public static EcsEntity SendMessage<T>(this EcsWorld world, T message) where T : struct
    {
        var entity = world.NewEntity();
        entity.Get<T>() = message;
        return entity;
    }
}