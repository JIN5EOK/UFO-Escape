using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class PlayerStatus
{
    public Action onChangedStatus;
    private Player _player;
    public PlayerStatus(Player player, int hp, int speed)
    {
        _player = player;
        Hp = hp;
        Speed = speed;
    }
    
    [SerializeField] private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            _hp = value;
            onChangedStatus?.Invoke();
            if(_hp <= 0)
            {
                ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameFailedPanel");
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
    private void Awake()
    {
        State = PlayerDefaultState.GetState(this);
        _status = new PlayerStatus(this,3,4);
    }

    private void Update()
    {
        if (hitAgainTimer >= 0.0f)
        {
            hitAgainTimer -= Time.deltaTime;
        }
    }

    public void Move(Vector2 vec)
    {
        State.Move(vec);
    }
    public void Use()
    {
        State.Use();
    }
    private float hitAgainTime = 1.0f;
    private float hitAgainTimer = 0.0f;
    public void Damaged(int damage)
    {
        Status.Hp -= damage;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") && hitAgainTimer <= 0.0f)
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_impact_hit_03);
            Damaged(1);
            hitAgainTimer = hitAgainTime;
        }
    }
}
