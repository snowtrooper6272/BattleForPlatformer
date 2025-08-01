using UnityEngine;
using Transitions;
using States;
using Enemies;
using ServiceStates;

namespace Transitions
{
    public class AlienationTransition : Transition
    {
        private Player _target;
        private Enemy _enemy;
        private EnemyFinder _finder;
        private int _distance;

        public AlienationTransition(State targetState, Enemy enemy, EnemyFinder finder, int distance) : base(targetState)
        {
            _distance = distance;
            _enemy = enemy;
            _finder = finder;
        }

        public override bool IsNeedTransit()
        {
            if (_finder.FindTarget(_distance) == null)
                return true;

            return false;
        }
    }
}
