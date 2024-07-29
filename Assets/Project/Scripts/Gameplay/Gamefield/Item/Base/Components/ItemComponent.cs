using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct ItemComponent
{
    public Image IconView;
    [HideInInspector] public Transform Transform;
}