using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageDoor : MonoBehaviour
{
    private CommonGameManager _commonGameManager;
    
    // 좌측, 우측 문짝
    [SerializeField] private Transform _leftLeaf;
    [SerializeField] private Transform _rightLeaf;
    private bool _isOpen;
    
    private void Start()
    {
        _commonGameManager = FindObjectOfType<CommonGameManager>(); 
        _commonGameManager.onStageClear += OpenDoor;
    }

    private void OpenDoor()
    {
        
        if(_leftLeaf != null)
            Destroy(_leftLeaf.gameObject);
        if(_rightLeaf != null)
            Destroy(_rightLeaf.gameObject);
        _isOpen = true;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (_isOpen == false)
            return;

        if (other.CompareTag("Player"))
        {
            _commonGameManager.OpenNextStagePanel();
        }
    }
}
