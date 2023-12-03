using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameUI : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Transform hpIconLayoutGroup;
    private Player _player;
    private Image[] hpIcons;
    
    private void Start()
    {
        
        Init();
    }
    private void Init()
    {
        _pauseButton.onClick.AddListener(PressPause);
        hpIcons = hpIconLayoutGroup.GetComponentsInChildren<Image>();
        _player = FindObjectOfType<Player>();
        _player.Status.onChangedStatus += HpUIChange;
        HpUIChange();
    }
    private void HpUIChange()
    {
        int hp = _player.Status.Hp;
        for (int i = 0; i < hpIcons.Length; i++)
        {
            hpIcons[i].gameObject.SetActive(i < hp);
        }
    }

    private void PressPause()
    {
        ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "PausePanel");
    }
}
