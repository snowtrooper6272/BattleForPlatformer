using Enemies;
using System.Collections;
using System.Collections.Generic;
using Transitions;
using UnityEngine;

namespace States
{
    public class AttackState : State
    {
        private Enemy _enemy;
        private Player _target;
        private EnemyAnimator _animator;
        private int _damage = 3;
        private float _attackDelay = 1;
        private float _currentTime;

        public AttackState(List<Transition> transition, Enemy enemy, Player target, EnemyAnimator animator) : base(transition)
        {
            _enemy = enemy;
            _target = target;
            _animator = animator;
        }

        public override void Enter()
        {
            _animator.PlayAttack();
        }

        public override void Exit()
        {
            _animator.StopAttack();
        }

        public override void OnUpdate()
        {
            if (_currentTime >= _attackDelay) 
            {
                _currentTime = 0;
                _target.TakeDamage(_damage);
            }

            _currentTime += Time.deltaTime;
        }
    }
}
