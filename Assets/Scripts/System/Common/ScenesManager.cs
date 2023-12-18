using System;
using System.Collections;
using System.Collections.Generic;
using DesignPattern.Singleton;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoSingleton<ScenesManager>
{
    private Dictionary<string, string> _nextStageMap = new Dictionary<string, string>();
    //[SerializeField] private SceneAsset[] _stageScenes;
    void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        InitStageMap();
    }

    public void InitStageMap()
    {
        SceneAsset[] _stageScenes = ResourcesManager.Instance.GetResources<SceneAsset>(ResourcesManager.STAGE_PATH);  
        for (int i = 0; i < _stageScenes.Length; i++)
        {
            Debug.Log(_stageScenes[i].name);
            if (i == _stageScenes.Length - 1)
            {
                _nextStageMap.Add(_stageScenes[i].name, null);
            }
            else
            {
                _nextStageMap.Add(_stageScenes[i].name, _stageScenes[i + 1].name);
            }
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void NextStage()
    {
        string curScene = SceneManager.GetActiveScene().name;
        if (_nextStageMap.TryGetValue(curScene, out string nextScene))
        {
            LoadScene(_nextStageMap[curScene]);
        }
    }
    public void RestartStage()
    {
        string curScene = SceneManager.GetActiveScene().name;
        LoadScene(curScene);
    }
}
