using Enemies;
using System.Collections.Generic;
using Transitions;

namespace States
{
    public class PatrolState : State
    {
        private readonly Enemy _enemy;

        private ControlPoint[] _controlPoints;
        private float _speed = 5;
        private float _switchDistance = 2;
        private int _currentIndexOfPoint = 0;

        public PatrolState(List<Transition> transition, Enemy enemy, ControlPoint[] controlPoints) : base(transition) 
        {
            _enemy = enemy;
            _controlPoints = controlPoints;
        }

        public override void OnUpdate()
        {
            if (_enemy.PatrolPointAssembled(_controlPoints[_currentIndexOfPoint], _switchDistance))
            {
                SetNewTarget();
            }

            _enemy.Move(_controlPoints[_currentIndexOfPoint].transform.position, _speed);
        }

        public void SetNewTarget()
        {
            _currentIndexOfPoint = ++_currentIndexOfPoint % _controlPoints.Length;
        }
    }
}
