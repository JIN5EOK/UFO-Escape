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
        _resumeButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
            Destroy(this.gameObject);
        });
        _restartButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
            ScenesManager.Instance.RestartStage();
        });
        _mainMenuButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
            ScenesManager.Instance.LoadScene("MainMenu");
        });
    }
}
