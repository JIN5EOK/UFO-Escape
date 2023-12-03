using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] private string _stageName;
    [SerializeField] private Button _stageSelectButton;
    private void Start()
    {
        _stageSelectButton.onClick.AddListener(MoveScene);
    }
    private void MoveScene()
    {
        SceneManager.LoadScene(_stageName);
    }
}
