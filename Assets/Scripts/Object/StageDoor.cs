using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageDoor : MonoBehaviour
{
    [SerializeField] private CommonStageManager _commonStageManager;
    
    // 좌측, 우측 문짝
    [SerializeField] private Transform _leftLeaf;
    [SerializeField] private Transform _rightLeaf;
    [SerializeField] private bool _isOpen;
    
    private void Start()
    {
        _commonStageManager = FindObjectOfType<CommonStageManager>(); 
        _commonStageManager.onStageClear += OpenDoor;
    }

    private void OpenDoor()
    {
        _leftLeaf.transform.position += Vector3.left * 0.75f;
        _rightLeaf.transform.position += Vector3.right * 0.75f;
        _isOpen = true;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (_isOpen == false)
            return;

        if (other.CompareTag("Player"))
        {
            _commonStageManager.OpenNextStagePanel();
        }
    }
}
