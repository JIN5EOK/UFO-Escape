using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IInputable
{
    public void Move(Vector2 vec);
    public void Use();
}

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Player _inputTargetForDebug;
    
    private IInputable _inputTarget;
    private Vector2 _inputVector2;

    private void Awake()
    {
        if (_inputTargetForDebug == null)
            _inputTargetForDebug = FindObjectOfType<Player>();
                
        _inputTarget = _inputTargetForDebug;
    }

    private void Update()
    {
        if (_inputTarget == null)
            return;
        _inputVector2.x = Input.GetAxisRaw("Horizontal");
        _inputVector2.y = Input.GetAxisRaw("Vertical");
        
        Move();
        Use();
    }
    private void Move()
    {
        _inputTarget.Move(_inputVector2);
    }
    private void Use()
    {
        if (Input.GetKeyDown(KeyCode.Space) == false)
            return;
        
        _inputTarget.Use();
    }
}
