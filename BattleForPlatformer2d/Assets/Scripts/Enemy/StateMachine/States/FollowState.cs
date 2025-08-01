using Enemies;
using System.Collections;
using System.Collections.Generic;
using Transitions;
using ServiceStates;
using UnityEngine;

namespace States
{
    public class FollowState : State
    {
        private Enemy _enemy;
        private Player _target;
        private EnemyFinder _finder;
        private EnemyMover _mover;
        private float _speed = 5;

        public FollowState(List<Transition> transition, Enemy enemy, EnemyFinder finder, EnemyMover mover) : base(transition)
        {
            _enemy = enemy;
            _finder = finder;
            _mover = mover;
        }

        public override void OnUpdate()
        {
            if(_finder.TrackTarget)
                _mover.Move(_finder.TrackTarget.transform.position, _speed);
        }
    }
}
