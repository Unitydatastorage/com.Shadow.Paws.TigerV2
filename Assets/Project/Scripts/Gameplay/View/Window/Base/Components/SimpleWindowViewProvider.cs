using UnityEngine;
using Voody.UniLeo;

public abstract class SimpleWindowViewProvider<T> : MonoProvider<T> where T : struct, IWindowViewComponent
{
    [SerializeField] private GameObject _view;
    [SerializeField] private WindowViewInitialState _initialState;

    private void Awake()
    {
        value.View = _view;
        value.InitialState = _initialState;
    }
}