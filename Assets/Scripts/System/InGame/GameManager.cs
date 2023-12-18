using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DesignPattern.Singleton;
using UnityEditor;
using UnityEngine.SceneManagement;
/// <summary>
/// 인게임 관련 기능 총괄
/// </summary>

public abstract class GameManager : MonoBehaviour
{
    public enum StageStates
    {
        Play,
        Pause
    }
    public event Action onStageClear;
    protected void Start()
    {
        ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "InGameUI");
        gameObject.AddComponent<InputManager>();
        StageState = StageStates.Play;
    }

    private StageStates _stageState;
    public StageStates StageState
    {
        get => _stageState;
        set
        {
            _stageState = value;
            if (_stageState == StageStates.Pause)
                Time.timeScale = 0.0f;
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
    public void StageClear()
    {
        onStageClear?.Invoke();
    }
    public void OpenStageFailedPanel()
    {
        ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameFailedPanel");
    }
    public void OpenNextStagePanel()
    {
        var go = ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameClearPanel");
    }
}
