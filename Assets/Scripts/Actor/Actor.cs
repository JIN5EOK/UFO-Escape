using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class ActorStatus
{
    public event Action onDied;
    public event Action onChangedStatus;
    private Actor _target;
    public ActorStatus(Actor target, int hp, int speed)
    {
        _target = target;
        Hp = hp;
        Speed = speed;
    }

    public int MaxHp
    {
        get;
        set;
    }
    [SerializeField] private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            _hp = value;
            onChangedStatus?.Invoke();
            if (_hp <= 0)
            {
                onDied?.Invoke();
            }
        }
    }
    
    [SerializeField] private float _speed;
    public float Speed
    {
        get => _speed;
        set
        {
            _speed = value;
            onChangedStatus?.Invoke();
        } 
    }
}

public abstract class Actor : MonoBehaviour
{
    [SerializeField]
    private ActorStatus _status;
    
    public ActorStatus Status
    {
        get => _status;
        set => _status = value;
    }

    protected virtual void Start()
    {
        Status.MaxHp = Status.Hp;
    }
    
    public virtual void TakeDamage(int damage)
    {
        Status.Hp -= damage;
    }
}
