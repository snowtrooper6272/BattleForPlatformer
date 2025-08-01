using Enemies;
using System.Collections.Generic;
using Transitions;
using ServiceStates;

namespace States
{
    public class PatrolState : State
    {
        private readonly Enemy _enemy;

        private ControlPoint[] _controlPoints;
        private EnemyMover _mover;
        private float _speed = 5;
        private float _switchDistance = 2;
        private int _currentIndexOfPoint = 0;

        public PatrolState(List<Transition> transition, Enemy enemy, ControlPoint[] controlPoints, EnemyMover mover) : base(transition) 
        {
            _enemy = enemy;
            _controlPoints = controlPoints;
            _mover = mover;
        }

        public override void OnUpdate()
        {
            if (_enemy.PatrolPointAssembled(_controlPoints[_currentIndexOfPoint], _switchDistance))
            {
                SetNewTarget();
            }

            _mover.Move(_controlPoints[_currentIndexOfPoint].transform.position, _speed);
        }

        public void SetNewTarget()
        {
            _currentIndexOfPoint = ++_currentIndexOfPoint % _controlPoints.Length;
        }
    }
}
