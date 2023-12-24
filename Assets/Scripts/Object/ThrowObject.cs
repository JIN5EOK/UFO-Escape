using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Light))]
public class ThrowObject : MonoBehaviour
{
    //private List<GameObject> _hitEnemys = new List<GameObject>();
    private int _damage = 1;   
    private Rigidbody _rigidbody;
    private bool isHit = true;
    private Light _light;
    public bool IsReusable
    {
        get;
        set;
    } = true;
    private void Awake()
    {
        _light = gameObject.GetComponent<Light>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _light.color = Color.green;
        _light.range = 3;
        _light.intensity = 10;
    }
    public void PickUp(Player player)
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_jump_bounce_09);
        //_hitEnemys.Clear();
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = player.transform.position + Vector3.up * 2;
        transform.SetParent(player.transform);
    }
    public void Throw(Player player)
    {
        isHit = false;
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_jump_bounce_20);
        transform.position = player.transform.position + player.transform.forward + Vector3.up;
        _rigidbody.isKinematic = false;
        transform.SetParent(null);
        _rigidbody.AddForce(player.transform.forward * 1000);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isHit == true)
            return;
        if (_rigidbody.velocity.magnitude < 0.5f)
            return;
        // if (_hitEnemys.Contains(other.gameObject))
        //     return;
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            isHit = true;
            _rigidbody.velocity = Vector3.zero;
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_impact_hit_13);
            Enemy enemy = other.GetComponent<Enemy>();
            // _hitEnemys.Add(other.gameObject);
            enemy.TakeDamage(_damage);
            Debug.Log("적과 충돌");
            
            if(IsReusable == false)
                Destroy(gameObject);

            ResourcesManager.Instance.Instantiate(ResourcesManager.VFX_PATH + "FX_PowerUp_Coin_AB").transform.position = other.transform.position;
            
        }
    }
}
