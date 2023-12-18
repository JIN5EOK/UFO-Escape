using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameFailedPanel : UIBase
{
    
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _mainMenuButton;
    private void Start()
    {
        _retryButton.onClick.AddListener(() =>
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
