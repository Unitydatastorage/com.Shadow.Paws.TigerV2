using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

public class LoadSceneButtonProvider : MonoProvider<LoadSceneButtonComponent>
{
#if UNITY_EDITOR
    [Dropdown(nameof(SceneNames))]
#endif
    [SerializeField] private string _selectedScene;

#if UNITY_EDITOR
    private IReadOnlyCollection<string> SceneNames => SceneList.GetScenes();
#endif

    private void Awake() => value.SceneName = _selectedScene;
}