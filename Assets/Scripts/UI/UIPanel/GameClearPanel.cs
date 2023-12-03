using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameClearPanel : UIBase
{
    [SerializeField] private Button _retryBtn;
    [SerializeField] private Button _nextBtn;

    public string nextStage;
    private void Start()
    {
        _retryBtn.onClick.AddListener(() =>
        {
            GameManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
        });
        _nextBtn.onClick.AddListener(() =>
        {
            GameManager.Instance.LoadScene(nextStage);
        });
    }
}
