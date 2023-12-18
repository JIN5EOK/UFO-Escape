using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public interface IThrowable
{
    public void PickUp(Player player);
    public void Throw(Player player);
}
[RequireComponent(typeof(Rigidbody))]
public class ThrowObject : MonoBehaviour, IThrowable
{
    private List<GameObject> _hitEnemys = new List<GameObject>();
    private int _damage = 1;   
    private Rigidbody _rigidbody;

    public bool IsReusable
    {
        get;
        set;
    } = true;
    private void Awake()
    {
        Light light = gameObject.AddComponent<Light>();
        light.color = Color.green;
        light.range = 3;
        light.intensity = 10;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void PickUp(Player player)
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_jump_bounce_09);
        _hitEnemys.Clear();
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = player.transform.position + Vector3.up * 2;
        transform.SetParent(player.transform);
    }
    public void Throw(Player player)
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_jump_bounce_20);
        transform.position = player.transform.position;
        _rigidbody.isKinematic = false;
        transform.SetParent(null);
        _rigidbody.AddForce(player.transform.forward * 1000);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_rigidbody.velocity.magnitude < 0.5f)
            return;
        if (_hitEnemys.Contains(other.gameObject))
            return;
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_impact_hit_13);
            Enemy enemy = other.GetComponent<Enemy>();
            _hitEnemys.Add(other.gameObject);
            enemy.Damaged(_damage);
            Debug.Log("적과 충돌");
            
            if(IsReusable == false)
                Destroy(gameObject);
        }
    }
}
