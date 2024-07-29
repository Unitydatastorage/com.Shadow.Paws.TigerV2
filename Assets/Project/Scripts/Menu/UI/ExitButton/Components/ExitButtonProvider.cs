using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

public class ExitButtonProvider : MonoProvider<ExitButtonComponent>
{
    [SerializeField] private Button _button;
    private void Awake() => value.Button = _button;
}