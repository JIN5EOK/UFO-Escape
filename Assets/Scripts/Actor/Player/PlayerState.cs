using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerState
{
    protected Player _player;
    protected PlayerState(Player player)
    {
        this._player = player;
    }

    public virtual void Move(Vector2 vec)
    {
        if (vec == Vector2.zero)
        {
            if(_player.animator.GetBool("IsWalk") == true)
                _player.animator.SetBool("IsWalk", false);
            return;
        }
        else
        {
            if(_player.animator.GetBool("IsWalk") == false)
                _player.animator.SetBool("IsWalk", true);
        }
        float rotateDeg = Mathf.Rad2Deg * Mathf.Atan2(vec.y, vec.x * -1) - 90;
        Vector3 rotateVec = new Vector3(_player.transform.rotation.x, rotateDeg, _player.transform.rotation.z);
        _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, Quaternion.Euler(rotateVec), 100.0f);
        _player.transform.Translate(Vector3.forward * Time.deltaTime * (_player.Status.Speed));
    }
    public abstract void Use();
}

public class PlayerDefaultState : PlayerState
{
    protected PlayerDefaultState(Player player) : base(player) { }

    private static PlayerDefaultState _instance;
    
    public static PlayerDefaultState GetState(Player player)
    {
        if (_instance == null)
        {
            _instance = new PlayerDefaultState(player);
        }
        else
        {
            _instance._player = player;
        }
        return _instance;
    }

    public override void Use()
    {
        Vector3 origin = _player.transform.position;
        float radius = 1.0f;


        RaycastHit[] hits =
            Physics.SphereCastAll(origin, radius, Vector3.up, 0.0f);
        
        if (hits != null)
        {
            foreach(var h in hits)
            {
                if (h.transform.TryGetComponent<ThrowObject>(out ThrowObject tObj))
                {
                    _player.animator.SetBool("IsGrab", true);
                    tObj.PickUp(_player);
                    _player.PickUpObject = tObj;
                    _player.State = PlayerPickUpState.GetState(_player);
                    break;
                }
            }
        }
    }
}

public class PlayerPickUpState : PlayerState
{
    private static PlayerPickUpState _instance;
    protected PlayerPickUpState(Player player) : base(player) { }
    public static PlayerPickUpState GetState(Player player)
    {
        if (_instance == null)
        {
            _instance = new PlayerPickUpState(player);
        }
        else
        {
            _instance._player = player;
        }
        return _instance;
    }
    
    public override void Move(Vector2 vec)
    {
        base.Move(vec * 0.5f);
    }

    public override void Use()
    {
        _player.animator.SetBool("IsGrab", false);
        _player.animator.SetTrigger("Throw");
        _player.State = PlayerDefaultState.GetState(_player);
        _player.PickUpObject.Throw(_player);
    }
}
