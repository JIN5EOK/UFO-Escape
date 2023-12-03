using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommonEnemy : Enemy
{
    [SerializeField] 
    private float _moveSpeed;
    private float _detectDistance = 5.0f;
    private float _detectAngle = 90.0f;
    private bool _isDetect = false;
    private Player _target;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = _moveSpeed; 
        _target = FindObjectOfType<Player>();
    } 
    private void Update()
    {
        if (_isDetect == true)
        {
            navMeshAgent.SetDestination(_target.transform.position);
        }
        else
        {
            RandomMove();
            DetectPlayer();
        }
    }


    private float _randomMoveTimer = 0.0f;
    private float _randomMoveCycle = 5.0f;
    private void RandomMove()
    {
        if (_randomMoveTimer >= 0.0f)
        {
            
            _randomMoveTimer -= Time.deltaTime;
        }
        else
        {
            float rotate = Random.Range(0, 360f);
            transform.Rotate(new Vector3(0,rotate, 0));
            _randomMoveTimer = _randomMoveCycle;
        }
        Debug.Log(_randomMoveTimer);
        transform.Translate(transform.forward * Time.deltaTime);
    }
    
    private void DetectPlayer()
    {
        Vector3 targetDir = (_target.transform.position - this.transform.position).normalized;
        float dot = Vector3.Dot(this.transform.forward, targetDir);
        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;
        
        _isDetect = theta <= _detectAngle && Vector3.Distance(_target.transform.position, 
            this.transform.position) <= _detectDistance;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _detectDistance);
        if (_isDetect == true)
        {
            
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _target.transform.position);
        }
    }
}
