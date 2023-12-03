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
        _startButton.onClick.AddListener(PressStartButton);
        _helpButton.onClick.AddListener(PressHelpButton);
        _exitButton.onClick.AddListener(PressExitButton);
    }

    private void PressStartButton()
    {
        UIBase _startPanel = ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameStartPanel").GetComponent<UIBase>();
        _startPanel.onClose += () =>
        {
            ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "MainMenuPanel");
        };
        Destroy(this.gameObject);
    }
    private void PressHelpButton()
    {
        UIBase _helpPanel = ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "HelpPanel").GetComponent<UIBase>();
        _helpPanel.onClose += () =>
        {
            ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "MainMenuPanel");
        };
        Destroy(this.gameObject);
    }
    private void PressExitButton()
    {
        Application.Quit();
    }
}
