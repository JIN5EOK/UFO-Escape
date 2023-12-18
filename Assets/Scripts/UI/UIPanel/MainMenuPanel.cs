using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class MainMenuPanel : UIBase
{
    [SerializeField] Button _startButton;
    [SerializeField] Button _helpButton;
    [SerializeField] Button _exitButton;

    
    void Start()
    {
        AudioManager.Instance.PlayBgm(AudioManager.Bgms.music_8bit_jammer);
        _startButton.onClick.AddListener(PressStartButton);
        _helpButton.onClick.AddListener(PressHelpButton);
        _exitButton.onClick.AddListener(PressExitButton);
    }
    

    private void PressStartButton()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
        UIBase _startPanel = ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameStartPanel").GetComponent<UIBase>();
        _startPanel.onClose += () =>
        {
            ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "MainMenuPanel");
        };
        Destroy(this.gameObject);
    }
    private void PressHelpButton()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
        UIBase _helpPanel = ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "HelpPanel").GetComponent<UIBase>();
        _helpPanel.onClose += () =>
        {
            ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "MainMenuPanel");
        };
        Destroy(this.gameObject);
    }
    private void PressExitButton()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.ui_menu_button_click_01);
        Application.Quit();
    }
}
