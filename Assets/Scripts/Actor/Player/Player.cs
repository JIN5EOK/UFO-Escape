using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



[Serializable]
public class PlayerStatus
{
    [SerializeField] private float _speed;
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
}

public class Player : Actor, IInputable
{
    private PlayerState _state;
    public PlayerState State
    {
        get => _state;
        set => _state = value; 
    }

    public ThrowObject PickUpObject
    {
        get;
        set;
    }
    [SerializeField] private PlayerStatus _status;
    public PlayerStatus Status
    {
        get => _status;
        private set => _status = value;
    }
    private void Start()
    {
        State = PlayerDefaultState.GetState(this);
    }

    public void Move(Vector2 vec)
    {
        State.Move(vec);
    }

    public void Use()
    {
        State.Use();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("사망");
        }
    }
}
