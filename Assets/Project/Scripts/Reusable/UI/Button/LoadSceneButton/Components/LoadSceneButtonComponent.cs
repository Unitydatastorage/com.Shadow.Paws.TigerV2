using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct LoadSceneButtonComponent
{
    public Button Button;
    [HideInInspector] public string SceneName;
}