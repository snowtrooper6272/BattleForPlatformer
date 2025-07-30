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

        public FollowState(List<Transition> transition, Enemy enemy) : base(transition)
        {
            _enemy = enemy;
        }

        public override void OnUpdate()
        {
            if(_enemy.TrackTarget)
                _enemy.Move(_enemy.TrackTarget.transform.position, _speed);
        }
    }
}
