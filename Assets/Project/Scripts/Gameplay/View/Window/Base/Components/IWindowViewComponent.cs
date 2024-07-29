using UnityEngine;

public interface IWindowViewComponent
{
    GameObject View { get; set; }
    WindowViewInitialState InitialState { get; set; }
}