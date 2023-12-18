using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : Actor
{
    
    [SerializeField] private int _hp;

    public int MaxHp
    {
        get;
        private set;
    }
    public int Hp
    {
        get => _hp;
        protected set
        {
            _hp = value;
            
            if(_hp <= 0)
                Destroy(this.gameObject);
        }
    }

    protected void Start()
    {
        MaxHp = Hp;
    }

    public virtual void Damaged(int damage)
    {
        Hp -= damage;
    }
}