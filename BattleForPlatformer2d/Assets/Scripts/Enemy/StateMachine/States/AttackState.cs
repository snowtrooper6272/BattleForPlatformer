using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _delayOfAttack;

    private Coroutine _attacking;
    private bool _isNeedAttack = true;

    private IEnumerator Attacking() 
    {
        WaitForSeconds delay = new WaitForSeconds(_delayOfAttack);

        while (_isNeedAttack == true) 
        {
            _animator.PlayAttack();
            _target.TakeDamage(_damage);

            yield return delay;
        }
    }

    public override void Init(Player target)
    {
        _target = target;
        _attacking = StartCoroutine(Attacking());
    }

    public override void Exit()
    {
        StopCoroutine(_attacking);
        _animator.StopAttack();
    }
}
