using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class BossEnemy : Enemy
{
    private CannonBall _cannonBallPrefab;
    private Image _hpBar;
    private Transform _playerTrs;
    [SerializeField] private Transform _firePos;

    protected void Start()
    {

        base.Start();
        _playerTrs = FindObjectOfType<Player>().transform;
        GameObject barGo = ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "BossHPUI");
        _cannonBallPrefab = ResourcesManager.Instance.GetResource<GameObject>( ResourcesManager.OBJECT_PATH + "CannonBall").GetComponent<CannonBall>();
        _hpBar = barGo.transform.GetChild(0).GetChild(0).GetComponent<Image>();

        Status.onDied += () =>
        {
            ResourcesManager.Instance.Instantiate(ResourcesManager.OBJECT_PATH + "CardKey");
        };
    }
    
    private void Attack()
    {
        CannonBall ballObj = Instantiate(_cannonBallPrefab);
        ballObj.transform.position = _firePos.position;
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.explosion_large_01);
        ballObj.Launch(_playerTrs);
    }
    
    private void Update()
    {
        Vector3 lookPos = new Vector3(_playerTrs.position.x, transform.position.y, _playerTrs.position.z);
        transform.LookAt(lookPos);
        AttackTimer();
    }

    private float attackDelay = 7.5f;
    private float attackDelayRand = 2.5f;

    private float curAttckTimer = 5.0f;

    private float hpPer = 1.0f;


    private void AttackTimer()
    {

        if (curAttckTimer >= 0)
        {
            curAttckTimer -= Time.deltaTime;
        }
        else
        {

            //_animator.SetTrigger("FireTrigger"); 
            curAttckTimer = Random.Range(attackDelay - attackDelayRand, attackDelay + attackDelayRand) * Mathf.Clamp(hpPer, 0.5f, 1.0f);
            Attack();
            Debug.Log("공격");
        }
    }

    public override void TakeDamage(int damage)
    {
        hpPer = (float)(Status.Hp - damage) / (float)Status.MaxHp;
        if (Status.Hp - damage > 0)
            _hpBar.fillAmount = hpPer;
        else
            _hpBar.fillAmount = 0;
        base.TakeDamage(damage);
    }
}
