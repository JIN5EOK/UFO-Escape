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
    private Transform playerTrs;
    private void Start()
    {
        base.Start();
        playerTrs = FindObjectOfType<Player>().transform;
        GameObject barGo = ResourcesManager.Instance.Instantiate(ResourcesManager.UI_PATH + "BossHPUI");
        _cannonBallPrefab = ResourcesManager.Instance.GetResource<GameObject>( ResourcesManager.OBJECT_PATH + "CannonBall").GetComponent<CannonBall>();
        _hpBar = barGo.transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }

    protected override void OnDestroy()
    {
        ResourcesManager.Instance.Instantiate(ResourcesManager.OBJECT_PATH + "CardKey");
        base.OnDestroy();
    }
    
    private void Attack()
    {
        CannonBall ballObj = Instantiate(_cannonBallPrefab);
        ballObj.transform.position = this.transform.position;
        AudioManager.Instance.PlaySfx(AudioManager.Sfxs.explosion_large_01);
        ballObj.Launch(playerTrs);
    }
    
    private void Update()
    {
        Vector3 lookPos = new Vector3(playerTrs.position.x, transform.position.y, playerTrs.position.z);
        transform.LookAt(lookPos);
        AttackTimer();
    }

    private float attackDelay = 7.5f;
    private float attackDelayRand = 2.5f;

    private float curAttckTimer = 5.0f;
    private void AttackTimer()
    {
        if (curAttckTimer >= 0)
        {
            curAttckTimer -= Time.deltaTime;
        }
        else
        {
            curAttckTimer = Random.Range(attackDelay - attackDelayRand, attackDelay + attackDelayRand);
            Attack();
        }
    }

    public override void Damaged(int damage)
    {
        base.Damaged(damage);

        if (Hp > 0)
            _hpBar.fillAmount = (float)Hp / (float)MaxHp;
    }
}
