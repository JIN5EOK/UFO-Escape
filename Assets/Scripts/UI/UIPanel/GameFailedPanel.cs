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
        _retryButton.onClick.AddListener(() => GameManager.Instance.LoadScene(SceneManager.GetActiveScene().name));
        _mainMenuButton.onClick.AddListener(() => GameManager.Instance.LoadScene("MainMenu"));
    }
    
}
