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
        private EnemyAnimator _animator;
        private int _damage = 3;
        private float _attackDelay = 1;
        private float _currentTime;

        public AttackState(List<Transition> transition, Enemy enemy, EnemyAnimator animator) : base(transition)
        {
            _enemy = enemy;
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
            if (_currentTime >= _attackDelay && _enemy.TrackTarget) 
            {
                _currentTime = 0;
                _enemy.TrackTarget.TakeDamage(_damage);
            }

            _currentTime += Time.deltaTime;
        }
    }
}
