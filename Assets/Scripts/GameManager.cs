using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DesignPattern.Singleton;

/// <summary>
/// 인게임 관련 기능 총괄
/// </summary>

public class GameManager : MonoSingleton<GameManager>
{
    protected new void Awake()
    {
        base.Awake();
    }
    
    public event Action onStageClear;

    public void StageClear()
    {
        onStageClear?.Invoke();
    }
}
