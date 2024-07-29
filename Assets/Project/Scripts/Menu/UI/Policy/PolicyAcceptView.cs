using UnityEngine;

public class PolicyAcceptView : MonoBehaviour
{
    [SerializeField] private GameObject _view;

    private const string ShowedKey = "PolicyShowed";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(ShowedKey)) Destroy(_view);
        else _view.SetActive(true);
    }

    public void Close()
    {
        PlayerPrefs.SetInt(ShowedKey, 1);
        Destroy(_view);
    }
}