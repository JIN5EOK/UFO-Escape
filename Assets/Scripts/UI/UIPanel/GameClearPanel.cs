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
    private void Start()
    {
        _retryBtn.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
            ScenesManager.Instance.RestartStage();
        });
        _nextBtn.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
            ScenesManager.Instance.NextStage();
        });
    }
}
