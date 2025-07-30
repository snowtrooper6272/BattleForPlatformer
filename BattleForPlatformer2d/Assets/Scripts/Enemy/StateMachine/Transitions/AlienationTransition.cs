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
        private int _distance;

        public AlienationTransition(State targetState, Enemy enemy, int distance) : base(targetState)
        {
            _distance = distance;
            _enemy = enemy;
        }

        public override bool IsNeedTransit()
        {
            if (_enemy.FindTarget(_distance) == null)
                return true;

            return false;
        }
    }
}
