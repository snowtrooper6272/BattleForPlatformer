using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _switchDistance;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform[] _patrolPoint;

    private int _currentIndexOfPoint = 0;

    private void Update()
    {
        if (PatrolPointAssembled())
        {
            SetNewTarget();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Init(Player target)
    {
        
    }

    public override void Exit()
    {
        
    }

    public void SetNewTarget() 
    {
        _currentIndexOfPoint = ++_currentIndexOfPoint % _patrolPoint.Length;
    }

    public void Move() 
    {
        _rigidbody2D.velocity = (_patrolPoint[_currentIndexOfPoint].position - transform.position).normalized * _speed;
    }

    public bool PatrolPointAssembled() 
    {
        Vector2 offset = _patrolPoint[_currentIndexOfPoint].position - transform.position;

        return offset.sqrMagnitude <= _switchDistance * _switchDistance;
    }
}
