using UnityEngine;

public struct HUDViewComponent : IWindowViewComponent
{
    public GameObject View { get; set; }

    public WindowViewInitialState InitialState { get; set; }
}