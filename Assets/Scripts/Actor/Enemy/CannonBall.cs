using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// 보스가 발사하는 대포알
/// <summary>
/// 1. 날아가서 어딘가 부딪히기 전 까지는 대포알
/// 2. 부딪힌 후에는 일반 던지기 오브젝트로 전환
/// </summary>
public class CannonBall : MonoBehaviour
{
    protected static readonly int MAXDROPCNT = 3;
    private bool _isDrop;
    private Rigidbody _rigidbody;
    private bool _isHit = false;
    public void Launch(Transform target)
    {
        //this.transform.LookAt(target);
        Vector3 vec3 = (target.position - this.transform.position).normalized;
        vec3.y = 0;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(vec3 * 250);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ThrowObject"))
            return;

        if (_isHit == true)
            return;

        _isHit = true;
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfxs.retro_impact_hit_03);
            other.GetComponent<Player>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        else
        {
            if (MAXDROPCNT <= FindObjectsOfType<ThrowObject>().Length)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _rigidbody.useGravity = true;
                // 던지는 오브젝트로 변환
                gameObject.layer = LayerMask.NameToLayer("Default");
                gameObject.tag = "ThrowObject";
                GameObject g = transform.GetChild(0).gameObject;
                g.transform.SetParent(this.transform);
                g.layer = LayerMask.NameToLayer("ThrowObject");
                
                ThrowObject thO = gameObject.AddComponent<ThrowObject>();
                thO.IsReusable = false;
                Destroy(this);
                _isDrop = true;   
            }
        }
    }
    
    
}
