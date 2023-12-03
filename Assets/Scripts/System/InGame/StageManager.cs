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

public abstract class StageManager : MonoBehaviour
{
    [SerializeField] private string _nextStage;
    public enum StageStates
    {
        Play,
        Pause
    }

    private StageStates _stageState;
    public StageStates StageState
    {
        get => _stageState;
        set
        {
            if (_stageState == StageStates.Pause)
                Time.timeScale = 0.0f;
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
    public event Action onStageClear;
    public void StageClear()
    {
        onStageClear?.Invoke();
    }
    public event Action onStageFailed;
    
    public void OpenStageFailedPanel()
    {
        ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameFailedPanel");
    }
    public void OpenNextStagePanel()
    {
        var go = ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameClearPanel");
        go.GetComponent<GameClearPanel>().nextStage = _nextStage;
    }
}
