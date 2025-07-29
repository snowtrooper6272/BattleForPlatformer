using UnityEngine;
using Transitions;
using States;
using Enemies;

namespace Transitions
{
    public class AlienationTransition : Transition
    {
        private Player _target;
        private Enemy _enemy;
        private float _distance;

        public AlienationTransition(State targetState, Player target, Enemy enemy, float distance) : base(targetState)
        {
            _distance = distance;
            _target = target;
            _enemy = enemy;
        }

        public override bool IsNeedTransit()
        {
            if ((_target.transform.position - _enemy.transform.position).sqrMagnitude > _distance * _distance)
                return true;

            return false;
        }
    }
}
