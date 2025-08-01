using Enemies;
using ServiceStates;
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
        private EnemyFinder _finder;
        private int _damage = 3;
        private float _attackDelay = 1;
        private float _currentTime;

        public AttackState(List<Transition> transition, Enemy enemy, EnemyAnimator animator, EnemyFinder finder) : base(transition)
        {
            _enemy = enemy;
            _animator = animator;
            _finder = finder;
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
            Player target = _finder.TrackTarget;

            if (_currentTime >= _attackDelay && target)
            {
                _currentTime = 0;
                target.TakeDamage(_damage);
            }

            _currentTime += Time.deltaTime;
        }
    }
}
