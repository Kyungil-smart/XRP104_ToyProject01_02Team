using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] private Button _toTitleButton;

    private void Awake() => GameManager.Instance.OnStageClear += Activate;
    private void OnEnable() => _toTitleButton.onClick.AddListener(ToTitle);
    private void Start() => Deactivate();
    private void OnDisable() => _toTitleButton.onClick.RemoveListener(ToTitle);
    private void OnDestroy() => GameManager.Instance.OnStageClear -= Activate;

    private void Activate()
    {
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void ToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
