using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
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

    public Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        State = PlayerDefaultState.GetState(this);
    }

    private void Start()
    {
        Status.onDied += () => ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "GameFailedPanel");
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
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") && hitAgainTimer <= 0.0f)
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_impact_hit_03);
            TakeDamage(1);
            hitAgainTimer = hitAgainTime;
        }
    }
}
