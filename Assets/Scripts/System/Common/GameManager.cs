using System;
using System.Collections;
using System.Collections.Generic;
using DesignPattern.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoSingleton<GameManager>
{
    void Awake()
    {
        base.Awake();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
