using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : Actor
{
    [SerializeField] private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            _hp = value;
            
            if(_hp <= 0)
                Destroy(this.gameObject);
        }
    }
}