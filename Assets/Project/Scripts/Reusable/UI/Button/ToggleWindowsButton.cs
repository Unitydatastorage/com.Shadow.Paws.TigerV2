using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleWindowsButton : MonoBehaviour
{
    [SerializeField] private GameObject _windowToEnable;
    [SerializeField] private GameObject _windowToDisable;

    private void Awake() => GetComponent<Button>().onClick.AddListener(SwitchState);

    private void SwitchState()
    {
        _windowToEnable.SetActive(true);
        _windowToDisable.SetActive(false);
    }
}