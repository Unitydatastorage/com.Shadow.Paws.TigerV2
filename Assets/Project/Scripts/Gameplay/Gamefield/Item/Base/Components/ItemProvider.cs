using Voody.UniLeo;

public class ItemProvider : MonoProvider<ItemComponent>
{
    private void Awake() => value.Transform = transform;
}