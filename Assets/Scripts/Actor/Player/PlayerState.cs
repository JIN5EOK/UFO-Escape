using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
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
            Physics.SphereCastAll(origin, radius, Vector3.up, 0.0f, 1 << LayerMask.NameToLayer("ThrowObject"));
        
        if (hits != null)
        {
            foreach(var h in hits)
            {
                if (h.transform.TryGetComponent<ThrowObject>(out ThrowObject tObj))
                {
                    tObj.PickUp(_player);
                    _player.State = PlayerPickUpState.GetState(_player, tObj);
                    break;
                }
            }
        }
    }
}

public class PlayerPickUpState : PlayerState
{
    private static PlayerPickUpState _instance;
    protected PlayerPickUpState(Player player, ThrowObject throwObj = null) : base(player)
    {
        _throwObject = throwObj;
    }
    public static PlayerPickUpState GetState(Player player, ThrowObject throwObj = null)
    {
        if (_instance == null)
        {
            _instance = new PlayerPickUpState(player, throwObj);
        }
        else
        {
            _instance._player = player;
            _instance._throwObject = throwObj;
        }
        return _instance;
    }
    
    private ThrowObject _throwObject;
    
    public override void Move(Vector2 vec)
    {
        base.Move(vec * 0.5f);
    }

    public override void Use()
    {
        _player.State = PlayerDefaultState.GetState(_player);
        _throwObject.Throw(_player);
    }
}
