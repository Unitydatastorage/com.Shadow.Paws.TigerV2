using UnityEngine;

public struct WinViewComponent : IWindowViewComponent
{
    public GameObject View { get; set; }
    public WindowViewInitialState InitialState { get; set; }
}