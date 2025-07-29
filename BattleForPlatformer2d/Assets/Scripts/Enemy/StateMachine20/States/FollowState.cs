using Enemies;
using System.Collections;
using System.Collections.Generic;
using Transitions;
using UnityEngine;

namespace States
{
    public class FollowState : State
    {
        private Enemy _enemy;
        private Player _target;
        private float _speed = 5;

        public FollowState(List<Transition> transition, Enemy enemy, Player target) : base(transition)
        {
            _enemy = enemy;
            _target = target;
        }

        public override void OnUpdate()
        {
            _enemy.Move(_target.transform.position, _speed);
        }
    }
}
