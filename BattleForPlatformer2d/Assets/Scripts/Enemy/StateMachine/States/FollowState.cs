using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void Update()
    {
        Move();
    }

    public override void Init(Player target)
    {
        _target = target;
    }

    public override void Exit()
    {

    }

    public void Move()
    {
        _rigidbody2D.velocity = (_target.transform.position - transform.position).normalized * _speed;
    }
}
