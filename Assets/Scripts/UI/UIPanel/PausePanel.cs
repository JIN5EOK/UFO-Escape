using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PausePanel : UIBase
{
    [SerializeField] Button _resumeButton;
    [SerializeField] Button _restartButton;
    [SerializeField] Button _mainMenuButton;

    private void Start()
    {
        _resumeButton.onClick.AddListener(() => Destroy(this.gameObject));
        _restartButton.onClick.AddListener(() => GameManager.Instance.LoadScene(SceneManager.GetActiveScene().name));
        _mainMenuButton.onClick.AddListener(() => GameManager.Instance.LoadScene("MainMenu"));
    }
}
