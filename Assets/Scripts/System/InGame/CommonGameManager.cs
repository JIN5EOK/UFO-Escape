using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DesignPattern.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 일반 스테이지 담당 스크립트, 모든 적이 죽으면 문을 여는 역할을 수행합니다
/// </summary>
public class CommonGameManager : GameManager
{
    private int leftEnemy;
    private StageDoor _stageDoor;
    
    protected void Start()
    {
        
        base.Start();
        AudioManager.Instance.PlayBgm(AudioManager.Bgms.music_bytes_the_retro_adventure);
        _stageDoor = FindObjectOfType<StageDoor>();
        Enemy[] tempEnemies = FindObjectsOfType<Enemy>();

        if (_stageDoor == null || tempEnemies.Length == 0)
        {
            Debug.Log("문이 없거나 적이 없음");
            return;
        }
        // 맵에 있는 몬스터들한테 사망시 이벤트 걸기
        foreach (var e in tempEnemies)
        {
            leftEnemy++;
            e.Status.onDied += RemoveEnemy;
        }
    }
    private void RemoveEnemy()
    {
        leftEnemy--;
        Debug.Log("남은 적" + leftEnemy);
        if (leftEnemy <= 0)
        {
            StageClear();
        }
    }
}
