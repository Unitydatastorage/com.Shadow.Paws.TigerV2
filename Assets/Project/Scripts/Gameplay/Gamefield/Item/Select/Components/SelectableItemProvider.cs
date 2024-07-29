using UnityEngine;
using UnityEngine.EventSystems;
using Voody.UniLeo;

[RequireComponent(typeof(EventTrigger))]
public class SelectableItemProvider : MonoProvider<SelectableItemComponent>
{
    private void Awake()
    {
        value.EventTrigger = GetComponent<EventTrigger>();
        value.Transform = transform;
    }
}
