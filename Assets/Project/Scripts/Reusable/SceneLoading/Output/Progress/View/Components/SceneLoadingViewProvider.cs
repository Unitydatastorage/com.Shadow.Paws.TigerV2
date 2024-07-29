using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

[RequireComponent(typeof(Slider))]
public class SceneLoadingViewProvider :
    MonoProvider<SceneLoadingViewComponent>
{
    private void Awake() => value.Bar = GetComponent<Slider>();
}