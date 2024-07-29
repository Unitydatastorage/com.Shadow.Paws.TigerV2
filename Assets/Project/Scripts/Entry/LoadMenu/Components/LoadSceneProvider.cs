using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

public class LoadSceneProvider : MonoProvider<LoadSceneRequest>
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